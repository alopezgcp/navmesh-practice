using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("EndScene");
    }
}
