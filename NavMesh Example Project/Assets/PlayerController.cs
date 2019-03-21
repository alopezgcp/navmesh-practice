using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera maincam;
    public NavMeshAgent agent;

    private void Start()
    {
        maincam = Camera.main;    
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
