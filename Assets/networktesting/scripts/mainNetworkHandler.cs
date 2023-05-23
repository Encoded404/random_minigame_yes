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
    List<dataStruct> structQueue = new List<dataStruct>();

    void sendString(string data)
    {
        stringQueue.Add(data);
    }

    void sendInt(int data)
    {
        intQueue.Add(data);
    }

    void sendDouble(double data)
    {
        doubleQueue.Add(data);
    }

    void sendAbstract(object data)
    {
        abstractQueue.Add(data);
    }

    void sendAbstractStruct(dataStruct data)
    {
        structQueue.Add(data);
    }

    void Awake()
    {
        // Initialize any necessary components or variables
    }

    void Start()
    {
        DeepNetworkManagerInstance.Main();
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