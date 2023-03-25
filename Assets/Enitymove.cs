using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enitymove : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed;
    SpriteRenderer sr;
    public float Direction { get; private set; }



    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        int prevWaypointIndex;

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            prevWaypointIndex = currentWaypointIndex;
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0;
            // Change direction for default layer only
            if (gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                if (waypoints[currentWaypointIndex].transform.position.x > waypoints[prevWaypointIndex].transform.position.x)
                {
                    sr.flipX = true;
                    Direction = 1.1f;
                }
                else
                {
                    sr.flipX = false;
                    Direction = -1.1f;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

}
