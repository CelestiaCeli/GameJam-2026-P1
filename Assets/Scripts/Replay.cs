using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    [SerializeField] private int scene;
    public void OnPress()
    {
        SceneManager.LoadScene(scene);
    }
}
