using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    public GameObject goalPrefab;
    private bool goalInstantiated;
    public int count;

    void Start()
    {
        goalInstantiated = false;
        count = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 0 && goalInstantiated == false)
        {
            Instantiate(goalPrefab);
            goalInstantiated = true;
        }
    }
}
