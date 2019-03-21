using UnityEngine;

public class PrizeController : MonoBehaviour
{
    public PrizeManager prizes;

    private void OnCollisionEnter()
    {
        Destroy(this.gameObject);
        prizes.count--;
    }
}
