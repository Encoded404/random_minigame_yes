using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneInitializerScript : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField]
    private GameObject[] initializerGameObjects;
    [SerializeField]
    private Scene firstLoadScene;

    int localSceneIndex = 1;

    bool doTriggeredUpdate = true;
    void Update()
    {
        if(doTriggeredUpdate)
        {
            triggeredUpdate();
        }
    }
    void triggeredUpdate()
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
            SceneManager.LoadScene(sceneIndex);
            doTriggeredUpdate = false;
        }
    }
    public void loadNewScene(int sceneIndex)
    {
        localSceneIndex=sceneIndex;
        doTriggeredUpdate = true;
    }
}
