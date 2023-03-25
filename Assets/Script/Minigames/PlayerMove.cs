using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
        private Rigidbody2D rb2D;
        public float moveSpeed = 5f;
        private float horizontalInput;
        private float verticalInput;
        public GameObject bullet;
        private Transform getransform;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        

    }

    
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }
}

