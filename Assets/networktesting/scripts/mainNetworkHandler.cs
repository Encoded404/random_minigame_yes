using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class mainNetworkHandler : MonoBehaviour
{
    deepNetworkManager DeepNetworkManagerInstance = new deepNetworkManager();


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

    Dictionary<int,string> stringQueue = new Dictionary<int, string>();

    /// <summary>
    /// sends a string to the server
    /// </summary>
    /// <param name="data"></param>
    public void sendString(int packetID, string data)
    {
        if (stringQueue.ContainsKey(packetID))
        {
            stringQueue[packetID] = data;
        }
        else
        {
            stringQueue.Add(packetID, data);
        }
    }

    Dictionary<int,int> intQueue = new Dictionary<int, int>();
    /// <summary>
    /// sends a int to the server
    /// </summary>
    /// <param name="data"></param>
    public void sendInt(int packetID, int data)
    {
        if (intQueue.ContainsKey(packetID))
        {
            intQueue[packetID] = data;
        }
        else
        {
            intQueue.Add(packetID, data);
        }
    }

    Dictionary<int,double> doubleQueue = new Dictionary<int,double>();
    /// <summary>
    /// sends a double to the server. an implesit conversion exist from int and float to double so they can be inputed instead
    /// </summary>
    /// <param name="data"></param>
    public void sendDouble(int packetID, double data)
    {
        if (doubleQueue.ContainsKey(packetID))
        {
            doubleQueue[packetID] = data;
        }
        else
        {
            doubleQueue.Add(packetID, data);
        }
    }

    Dictionary<int,object> abstractQueue = new Dictionary<int, object>();
    /// <summary>
    /// sends a object to the server and directly to all clients. it is sent raw so you need to handle the data yourself. REMEMBER the data needs to be serelizable by newtonsoft.json
    /// </summary>
    /// <param name="data"></param>
    public void sendAbstract(int packetID, object dataObject)
    {
        if (abstractQueue.ContainsKey(packetID))
        {
            abstractQueue[packetID] = dataObject;
        }
        else
        {
            abstractQueue.Add(packetID, dataObject);
        }
    }

    Dictionary<int,object> structQueue = new Dictionary<int, object>();
    /// <summary>
    /// <if you are sending player data please use "sendPlayerData()"> sends a struct to the server and directly to all clients. it is sent raw so you need to handle the data yourself. REMEMBER the data inside the struct needs to be serelizable by newtonsoft.json 
    /// </summary>
    /// <param name="data"></param>
    public void sendAbstractStruct(int packetID, object dataStruct)
    {
        if (structQueue.ContainsKey(packetID))
        {
            structQueue[packetID] = dataStruct;
        }
        else
        {
            structQueue.Add(packetID, dataStruct);
        }
    }

    Dictionary<int,object> playerDataQueue = new Dictionary<int,object>();
    struct sendStruct
    {
            int playerID;
            public object Object;
    }
    /// <summary>
    /// sends a struct to the server and directly to all clients together with player ID. it is sent raw so you need to handle the data yourself. REMEMBER the data inside the struct needs to be serelizable by newtonsoft.json 
    /// </summary>
    /// <param name="data"></param>
    public void sendPlayerData(int packetID, object dataStruct)
    {
        sendStruct ST = new sendStruct();
        ST.Object = dataStruct;
        if (doubleQueue.ContainsKey(packetID))
        {
            playerDataQueue[packetID] = ST;
        }
        else
        {
            playerDataQueue.Add(packetID, ST);
        }
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