using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class mainNetworkHandler : MonoBehaviour
{
    deepNetworkManager DeepNetworkManagerInstance = new deepNetworkManager();

    List<string> stringQueue = new List<string>();
    List<int> intQueue = new List<int>();
    List<double> doubleQueue = new List<double>();
    List<object> abstractQueue = new List<object>();
    List<object> structQueue = new List<object>();

    /// <summary>
    /// this is called when the client recieves any data at all. all data is raw so no fancy things for you this time
    /// </summary>
    public event EventHandler<string> recievedAnyRawData;
    void recievedAnyRawDataFunktion(string rawData) recievedAnyRawData(rawData);

    /// <summary>
    /// this is called when it recieves a Object, Struct, Int, Double or String
    /// </summary>
    public event EventHandler<object> recievedAnyData;
    void recievedAnyDataFunktion(object data) recievedAnyData(data);


    /// <summary>
    /// this is called when the client recieves data send by a SendAbstact() call
    /// </summary>
    public event EventHandler<object> receivedRandomData;
    void recievedRandomDataFunktion(object data) recievedRandomData(data);

    /// <summary>
    /// this is called when the client recieves data send by a SendAbstractStruct() call
    /// </summary>
    public event EventHandler<object> receivedRandomStruct;
    void recievedRandomStructFunktion(object structData) recievedAnyRawData(structData);


    /// <summary>
    /// this is called when the client recieves a string
    /// </summary>
    public event EventHandler<string> receivedString;
    void recievedStringFunktion(string stringData) recievedAnyRawData(stringData);

    /// <summary>
    /// this is called when the client recieves a int
    /// </summary>
    public event EventHandler<int> receivedInt;
    void recievedIntFunktion(int intData) recievedInt(intData);

    /// <summary>
    /// this is called when the client recieves a double
    /// </summary>
    public event EventHandler<double> receivedDouble;
    void recievedDoubleFunktion(double doubleData) recievedDouble(doubleData);


    /// <summary>
    /// sends a string to the server
    /// </summary>
    /// <param name="data"></param>
    public void sendString(string data)
    {
        stringQueue.Add(data);
    }

    /// <summary>
    /// sends a int to the server
    /// </summary>
    /// <param name="data"></param>
    public void sendInt(int data)
    {
        intQueue.Add(data);
    }

    /// <summary>
    /// sends a double to the server. an implesit conversion exist from int and float to double so they can be inputed instead
    /// </summary>
    /// <param name="data"></param>
    public void sendDouble(double data)
    {
        doubleQueue.Add(data);
    }

    /// <summary>
    /// sends a object to the server and directly to all clients. using the data you need to handle youself on this one. REMEMBER the data needs to be serelizable by newtonsoft.json
    /// </summary>
    /// <param name="data"></param>
    public void sendAbstract(object dataObject)
    {
        abstractQueue.Add(dataObject);
    }

    /// <summary>
    /// sends a struct to the server and directly to all clients. using the data you need to handle youself on this one. REMEMBER the data inside the struct needs to be serelizable by newtonsoft.json 
    /// </summary>
    /// <param name="data"></param>
    public void sendAbstractStruct(object dataStruct)
    {
        structQueue.Add(dataStruct);
    }

    void Awake()
    {
        // Initialize any necessary components or variables
    }

    void Start()
    {
        DeepNetworkManagerInstance.Main();


        DeepNetworkManagerInstance.recievedAnyRawData += recievedAnyRawDataFunktion;
        DeepNetworkManagerInstance.recievedAnyData += recievedAnyDataFunktion;
        DeepNetworkManagerInstance.recievedRandomData += recievedRandomDataFunktion;
        DeepNetworkManagerInstance.recievedStringData += recievedStringFunktion;
        DeepNetworkManagerInstance.recievedIntData += recievedIntFunktion;
        DeepNetworkManagerInstance.recievedDoubleData += recievedDoubleFunktion;


    }

    void Update()
    {
        // Process queued data and send it
        ProcessQueuedData();
    }

    void ProcessQueuedData()
    {
        // Create a dictionary to store all data
        Dictionary<string, object> jsonData = new Dictionary<string, object>();

        // Process and add the queued string data
        if (stringQueue.Count > 0)
        {
            jsonData["strings"] = stringQueue.ToArray();
            stringQueue.Clear();
        }

        // Process and add the queued int data
        if (intQueue.Count > 0)
        {
            jsonData["ints"] = intQueue.ToArray();
            intQueue.Clear();
        }

        // Process and add the queued double data
        if (doubleQueue.Count > 0)
        {
            jsonData["doubles"] = doubleQueue.ToArray();
            doubleQueue.Clear();
        }

        // Process and add the queued abstract data
        if (abstractQueue.Count > 0)
        {
            jsonData["abstracts"] = abstractQueue.ToArray();
            abstractQueue.Clear();
        }

        // Process and add the queued struct data
        if (structQueue.Count > 0)
        {
            jsonData["structs"] = structQueue.ToArray();
            structQueue.Clear();
        }

        // Convert the dictionary to a JSON string
        string jsonString = ConvertToJson(jsonData);

        // Send the JSON data using DeepNetworkManagerInstance or any other networking logic
        DeepNetworkManagerInstance.SendData(jsonString);
    }

    string ConvertToJson(object data)
    {
        // Convert the data to JSON format using Newtonsoft.Json
        return JsonConvert.SerializeObject(data);
    }
}