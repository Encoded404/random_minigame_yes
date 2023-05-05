using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollsionEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
