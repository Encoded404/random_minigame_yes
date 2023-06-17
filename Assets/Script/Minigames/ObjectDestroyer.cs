using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float destroyDelay = 20f; // The delay before the object is destroyed

    private void Start()
    {
        Invoke("DestroyObject", destroyDelay);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
