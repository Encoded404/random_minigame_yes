using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_testing : MonoBehaviour
{
    public static random_testing network_test;
    void Awake() 
    {
        network_test = this;    
    }

    public event Action test_change;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void button()
    {
        test_change();
    }
}
