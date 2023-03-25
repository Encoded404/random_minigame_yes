using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Gameplay Settings")]
    public float moveSpeed = 5f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Input Settings")]
    public string horizontalInput = "Horizontal";
    public string fireInput = "Fire1";

    private float nextFireTime = 0f;

    void Update()
    {
        // Move the player left or right based on input
        float horizontalAxis = Input.GetAxisRaw(horizontalInput);
        transform.Translate(Vector3.right * horizontalAxis * moveSpeed * Time.deltaTime);

        // Fire a bullet if the player presses the fire button and enough time has elapsed since the last shot
        if(Input.GetKeyDown("space") && Time.time >= nextFireTime)
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
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = Vector3.up * 10f;
    }
}
