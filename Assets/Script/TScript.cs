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
    private System.Action<string> onInputReceived;
    public bool waitingForInput = false;
    public Dictionary<string, Action<string[]>> commands = new Dictionary<string, Action<string[]>>();
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

    public void onEndEdit() {
        // Return if enter is not pressed
        if (!Input.GetKey(KeyCode.Return)) return;
        if (waitingForInput) {
            onInputReceived?.Invoke(input.text);
            return;
        }

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

    public void clear() {
        text.text = "user@localhost:$ ";
    }

    public void disableUserInput() {
        input.enabled = false;
    }

    public void enableUserInput() {
        input.enabled = true;
    }

    public string getAcutalInput(string message) {
        string response = "";
        GetInput(text => {
            response = text.ToString();
            Debug.Log(response);
            waitingForInput = false;
        });
        Debug.Log(response);
        return response; 
    }

    public void GetInput(System.Action<string> onInputReceived)
    {
        enableUserInput();
        waitingForInput = true;
        this.onInputReceived = onInputReceived;
    }

    public void handleCommand(string command, string[] arguments) {
        if (!commands.ContainsKey(command)) {
            println("Command not found: " + command);
            return;
        }
        commands[command](arguments);
    }
}
