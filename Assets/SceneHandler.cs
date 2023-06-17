using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        SceneManager.LoadScene("SpaceInvadersMinigame", LoadSceneMode.Additive);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
