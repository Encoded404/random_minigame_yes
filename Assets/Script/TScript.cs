using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
        
public class TScript : MonoBehaviour
{
    private List<string> lines;
    public TMP_InputField input;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        input.Select();
        input.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        input.Select();
        input.ActivateInputField();

    }
    void UpdateScreen(string lines) {
        
    }

    public void onEndEdit() {
        if (!Input.GetKey(KeyCode.Return)) return;
        text.text += input.text;
        text.text += "\nuser@localhost:$ ";
        input.text = "";
    }
}
