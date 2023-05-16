using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShootScript : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool friendly;

    private float nextFireTime = 0f;

    void Update()
    {
        
        
        // Fire a bullet if the player presses the fire button and enough time has elapsed since the last shot
        if ( Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }


    void Fire()
    {

        // Spawn a bullet prefab and set its position to the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Set the bullet's velocity to move straight up
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if(friendly)
            bulletRb.velocity = Vector2.up * 10f;
        else
            bulletRb.velocity = Vector2.up * -10f;  


    }
}
