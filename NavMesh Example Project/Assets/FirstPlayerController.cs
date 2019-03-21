using UnityEngine;
using UnityEngine.AI;

public class FirstPlayerController : MonoBehaviour
{
    private Camera maincam;
    public NavMeshAgent agent;

    void Start()
    {
        maincam = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
