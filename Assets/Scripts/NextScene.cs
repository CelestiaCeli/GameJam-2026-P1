using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [field: SerializeField]
    public GameObject fillUpBox { get; private set; }

    public GameObject playerGameObject { get; private set; }
    
    [field: SerializeField]
    public Vector3 fillUpAmount { get; private set; }

    private bool fillUpFinished = true;
    private float Time = 0;

    [field: SerializeField] public float SPEED { get; private set; } = 1;

    [field: SerializeField]
    public int nextScene {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fillUpFinished)
        {
            StartCoroutine(SceneTransition(collision));
        }
    }

    void Start()
    {
        fillUpBox.SetActive(false);
    }

    void Update()
    {
        if (!fillUpFinished)
        {
            Time += UnityEngine.Time.deltaTime;
            Transform originTransform = fillUpBox.transform;
            fillUpBox.transform.localScale = Vector2.Lerp(originTransform.localScale, fillUpAmount, Time * SPEED);
            
            if (fillUpBox.transform.localScale == fillUpAmount)
            {
                fillUpFinished = true;
            }
        }
    }
    
    public IEnumerator SceneTransition(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerGameObject = collision.gameObject;
            fillUpBox.SetActive(true);
            fillUpFinished = false;
            yield return new WaitUntil(() => fillUpFinished);
            Destroy(SoundManager.instance.gameObject);
            SceneManager.LoadScene(nextScene);
            yield return true;
            yield break;
        }

        yield return false;
    }
}
