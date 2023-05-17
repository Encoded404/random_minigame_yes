using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class fileHandler : MonoBehaviour
{
    public static fileHandler localFileHandler;
    void Awake()
    {
        localFileHandler = this;
    }

    StreamWriter streamWriter;
    StreamReader streamReader;

    string gameLocation;
    void Start()
    {
        gameLocation = Application.streamingAssetsPath;
        mainProblemHandler.Debuger.MakePublicDebug("game path is: " + gameLocation, "fileHandler");
        writeToDisk("lol", "lol");
    }

    /// <summary>
    /// reads the file with the specefied <paramref name="name"/> and <paramref name="extension"/> in the default data location.
    /// 
    /// returns "@file not found@" if the file doesn't exist
    /// </summary>
    /// <param name="name"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    public string readFromDisk(string name, string extension)
    {
        try
        {
            streamReader = new StreamReader(gameLocation+@"/"+name+"."+extension);
            return streamReader.ReadToEnd();
        }
        catch
        {
            return "@file not found@";
        }
    }
    /// <summary>
    /// reads a file with the <paramref name="name"/> and the <paramref name="extension"/> at the specefied <paramref name="path"/>
    /// 
    /// returns "@file not found@" if the file doesn't exist
    /// </summary>
    /// <param name="path">the path of the file</param>
    /// <param name="name">the name of the file</param>
    /// <param name="extension">the extension of the file. (no "." required)</param>
    /// <returns></returns>
    public string readFromDisk(string path, string name, string extension)
    {
        try
        {
            streamReader = new StreamReader(path + @"/" + name + "." + extension);
            return streamReader.ReadToEnd();
        }
        catch
        {
            return "@file not found@";
        }
    }

    /// <summary>
    /// writes at file with the specefied <paramref name="filename"/> and the <paramref name="extension"/> with the <paramref name="content"/> inside.
    /// 
    /// returns true if succesfull and false if it fails
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="extension"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool writeToDisk(string filename, string extension, string content)
    {
        try
        {
            Directory.CreateDirectory(gameLocation);
            mainProblemHandler.Debuger.MakePublicDebug("writing a file to disk: " + filename,"fileHandler");
            streamWriter = new StreamWriter(gameLocation+@"/"+filename+".txt");
            streamWriter.Write(content);
            streamWriter.Dispose();
        }
        catch(System.Exception e)
        {
            mainProblemHandler.Debuger.MakePublicDebug("encountered an error while writing to disc: "+e,"fileHandler");
            return false;
        }
        return true;
    }

    /// <summary>
    /// writes at file with the specefied <paramref name="filename"/> and the <paramref name="extension"/> with the <paramref name="content"/> inside.
    /// 
    /// returns true if succesfull and false if it fails
    /// </summary>
    /// <param name="location"></param>
    /// <param name="filename"></param>
    /// <param name="extension"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool writeToDisk(string location, string filename, string extension, string content)
    {
        try
        {
            Directory.CreateDirectory(gameLocation);
            mainProblemHandler.Debuger.MakePublicDebug("writing a file to disk: " + filename, "fileHandler");
            streamWriter = new StreamWriter(location + @"/" + filename + ".txt");
            streamWriter.Write(content);
            streamWriter.Dispose();
        }
        catch (System.Exception e)
        {
            mainProblemHandler.Debuger.MakePublicDebug("encountered an error while writing to disc: " + e, "fileHandler");
            return false;
        }
        return true;
    }
}
