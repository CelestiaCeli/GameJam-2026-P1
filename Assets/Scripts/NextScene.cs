using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(SceneTransition(collision));
    }

    public IEnumerator PlaceHolder()
    {
        yield return true;
    }
    
    public IEnumerator SceneTransition(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yield return StartCoroutine(PlaceHolder());
            SceneManager.LoadScene(nextScene);
            yield return true;
        }

        yield return false;
    }
}
