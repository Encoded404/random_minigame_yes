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
    /// Event triggered when any raw data is received by the client.
    /// </summary>
    public event EventHandler<string> recievedAnyRawData;
    void recievedAnyRawDataFunktion(object sender, string rawData) { recievedAnyRawData?.Invoke(sender, rawData); }

    /// <summary>
    /// Event triggered when any data (Object, Struct, Int, Double, or String) is received by the client.
    /// </summary>
    public event EventHandler<object> recievedAnyData;
    void recievedAnyDataFunktion(object sender, object data) { recievedAnyData?.Invoke(sender, data); }

    /// <summary>
    /// Event triggered when random data sent by a SendAbstract() call is received by the client.
    /// </summary>
    public event EventHandler<object> receivedRandomData;
    void recievedRandomDataFunktion(object sender, object data) { receivedRandomData?.Invoke(sender, data); }

    /// <summary>
    /// Event triggered when random struct data sent by a SendAbstractStruct() call is received by the client.
    /// </summary>
    public event EventHandler<object> receivedRandomStruct;
    void recievedRandomStructFunktion(object sender, object structData) { receivedRandomStruct?.Invoke(sender, structData); }

    /// <summary>
    /// Event triggered when a string is received by the client.
    /// </summary>
    public event EventHandler<string> receivedString;
    void recievedStringFunktion(object sender, string stringData) { receivedString?.Invoke(sender, stringData); }

    /// <summary>
    /// Event triggered when an int is received by the client.
    /// </summary>
    public event EventHandler<int> receivedInt;
    void recievedIntFunktion(object sender, int intData) { receivedInt?.Invoke(sender, intData); }

    /// <summary>
    /// Event triggered when a double is received by the client.
    /// </summary>
    public event EventHandler<double> receivedDouble;
    void recievedDoubleFunktion(object sender, double doubleData) { receivedDouble?.Invoke(sender, doubleData); }


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

    public void sendAbstractPlayerStruct(object dataStruct)
    {
        structQueue.Add(dataStruct);
    }

    void Awake()
    {
        // Initialize any necessary components or variables
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DeepNetworkManagerInstance.Main();

        DeepNetworkManagerInstance.recievedAnyRawData += recievedAnyRawDataFunktion;
        DeepNetworkManagerInstance.recievedAnyData += recievedAnyDataFunktion;
        DeepNetworkManagerInstance.recievedRandomData += recievedRandomDataFunktion;
        DeepNetworkManagerInstance.receivedString += recievedStringFunktion;
        DeepNetworkManagerInstance.receivedInt += recievedIntFunktion;
        DeepNetworkManagerInstance.receivedDouble += recievedDoubleFunktion;

        this.gameObject.GetComponent<deloadHelper>().RFD = true;
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