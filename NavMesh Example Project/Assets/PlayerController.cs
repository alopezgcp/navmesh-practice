using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    private Camera maincam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public PrizeManager prizeMgr;
    private int lastPrizeCount;

    private void Start()
    {
        lastPrizeCount = prizeMgr.count;
        agent.SetDestination(SetNearestPrize());

        maincam = Camera.main;
        agent.updateRotation = false;
    }

    void Update()
    {
    
        if (prizeMgr.count < lastPrizeCount && prizeMgr.count > 0)
        {
            lastPrizeCount = prizeMgr.count;
            agent.SetDestination(SetNearestPrize());
        }
        else if (prizeMgr.count == 0)
        {
            //set destination to goal (fixed position)
            agent.SetDestination(new Vector3(6f, 1.5f, 0f));
        }
    
    /*
        if (Input.GetMouseButton(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    */
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    Vector3 SetNearestPrize()
    {
        GameObject[] prizes = new GameObject[lastPrizeCount];
        int shortestPrizeIndex = 0;
        float shortestDistance = Mathf.Infinity;

        int prizeIndex = 0;
        foreach (Transform child in prizeMgr.transform)
        {
            prizes[prizeIndex] = child.gameObject;
            float distance = (child.position - this.transform.position).sqrMagnitude;
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                shortestPrizeIndex = prizeIndex;
            }
            prizeIndex++;
        }

        Vector3 destination = prizes[shortestPrizeIndex].transform.position;
        return destination;
    }
}
