using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;

public class mainProblemHandler : MonoBehaviour
{
    public static mainProblemHandler Debuger;

    private List<string> debugStringList = new List<string>();
    void Awake()
    {
        Debuger = this;
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExecuteOnCrash);
    }
    public event Action NetworkError;

    /// <summary>
    /// will print debugObject to the debug chat. and save it to a file if the Application crashes.
    /// 
    /// codeId is the name/id of the script.
    /// </summary>
    /// <param name="debugObject"></param>
    /// <param name="codeId"></param>
    public void MakePublicDebug(object debugObject,string codeID)
    {
        string debugString = debugObject.ToString() + " logged by: " + codeID;
        Debug.Log(debugString);
        debugStringList.Add(debugString);
    }
    /// <summary>
    /// will print to the debug chat. and save it to a file if the Application crashes.
    /// </summary>
    /// <param name="debugObject"></param>
    public void MakePublicDebug(object debugObject)
    {
        string debugString = debugObject.ToString() + " logged by: " + "unknown";
        Debug.Log(debugString);
        debugStringList.Add(debugString);
    }

    private void ExecuteOnCrash(object sender, UnhandledExceptionEventArgs args)
    {
        debugStringList.Append("the Application has run in to an exeption and will terminate. current running time is: "+Time.realtimeSinceStartup+" seconds");
        debugStringList.Append(sender.ToString()+" made and exception with the following args: "+args.ToString());
        Debug.Log(debugStringList.ToString());
        fileHandler.localFileHandler.writeToDisk("ApplicationCrash-"+DateTime.Now, debugStringList.ToString());
    }
}
