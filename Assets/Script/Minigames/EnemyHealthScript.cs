using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    public bool friendly = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("EnTookDmg");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (friendly)
                ScoreManager.AddToRedTeamScore(1);
            else
                ScoreManager.AddToGreenTeamScore(1);
            
            Destroy(gameObject);
        }
    }
}
