using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recever_tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        random_testing.network_test.test_change += youPressedButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void youPressedButton()
    {
        Debug.Log("you pressed the button");
    }
}
