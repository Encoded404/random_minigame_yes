using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextScene : MonoBehaviour
{
    [SerializeField]
    private GameObject[] initializerGameObjects;
    [SerializeField]
    private Scene firstLoadScene;
    void Update()
    {
        bool doDeload = true;
        for(int i = 0; i < initializerGameObjects.Length -1; i++)
        {
            if (initializerGameObjects[i].GetComponent<deloadHelper>().RFD == false)
            {
                doDeload = false;
            }
        }
        if(doDeload == true)
        {
            SceneManager.LoadScene(this.gameObject.scene.buildIndex + 1);
        }
    }
}
