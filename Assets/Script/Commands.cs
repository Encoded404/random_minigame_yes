using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Commands : MonoBehaviour
{
    public TScript terminal;
    public Dictionary<string, Action<string[]>> commands;

    void Start()
    {
        commands = terminal.commands;
        commands["ls"] = (arguments) => {
            terminal.println("Files\nOtherFiles\nFinalfiles");
        };

        commands["echo"] = (arguments) => {
            terminal.println(String.Join(" ", arguments));
        };

        commands["say"] = (arguments) => {
            terminal.println(terminal.playername + " >> " + String.Join(" ", arguments));
        };

        commands["gan"] = (arguments) => {
            int number = UnityEngine.Random.Range(1,100);
            terminal.println("I have choosen a number between 1 and 100");
            terminal.GetInput(text => {
                terminal.println(text);
            });
        };
    }
}
