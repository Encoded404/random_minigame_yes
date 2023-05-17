using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkHandler : MonoBehaviour
{
    deepNetworkManager DeepNetworkManagerInitializer = new deepNetworkManager();
    void Awake()
    {
        DeepNetworkManagerInitializer.Awake();
    }
    void Start()
    {
        deepNetworkManager.DNW.Main();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
