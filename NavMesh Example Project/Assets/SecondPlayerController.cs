using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class SecondPlayerController : MonoBehaviour
{
    private Camera maincam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    private void Start()
    {
        maincam = Camera.main;
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
