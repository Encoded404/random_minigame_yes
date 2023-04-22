using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TScript : MonoBehaviour
{
    private List<string> lines;

    public string playername = "playername";
    public TMP_InputField input;
    public TMP_Text text;
    public Dictionary<string, Action<TMP_Text, string[]>> commands = new Dictionary<string, Action<TMP_Text, string[]>>();
    // Start is called before the first frame update
    void Start()    
    {
        input.Select();
        input.ActivateInputField();

        commands["ls"] = (terminal, arguments) => {
            Debug.Log(arguments.ToString());
            println("Files\nOtherFiles\nFinalfiles");
        };

        commands["echo"] = (terminal, arguments) => {
            println(String.Join(" ", arguments));
        };

        commands["say"] = (terminal, arguments) => {
            println(playername + " >> " + String.Join(" ", arguments));
        };

        
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
        // Return if enter is not pressed
        if (!Input.GetKey(KeyCode.Return)) return;

        // Parse the commands and arguments
        string whole_command = input.text;
        string command = whole_command.Split(" ")[0];
        string[] arguments = whole_command.Split(" ")[1..];
        
        // Prepare for command
        text.text +=  whole_command + "\n";
        input.text = "";
        input.enabled = false;

        // Handle the command
        handleCommand(command, arguments);

        // Prepare for new commands
        text.text += "user@localhost:$ ";
        input.enabled = true;
    }

    public void println(string message) {
        print(message + "\n");
    }

    public void print(string message) {
        text.text += message;
    }

    public void handleCommand(string command, string[] arguments) {
        if (!commands.ContainsKey(command)) {
            println("Command not found: " + command);
            return;
        }
        commands[command](text, arguments);
    }
}
