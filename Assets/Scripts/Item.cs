using UnityEngine;

public class Item : MonoBehaviour
{
    protected void OnHit()
    {
        Destroy(gameObject);
    }
}
