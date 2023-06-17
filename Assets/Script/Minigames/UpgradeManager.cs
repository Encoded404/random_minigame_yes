using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private Transform container;
    private Transform itemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        itemTemplate = container.Find("itemTemplate");
        itemTemplate.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
