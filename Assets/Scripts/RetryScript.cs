using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
