using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CustomizerSaveSystem
{

    public static string dirName = "Ships";
    public static string fileName = "shipData.getoutofhere";
    public static string path = Application.persistentDataPath + "/" + "Ships" + "/";
    
    public static UnityEvent OnSave = new UnityEvent();

    public static void Save(CustomizerSelector selector)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path + selector.shipName, FileMode.Create);

        ShipData data = new ShipData(selector);

        formatter.Serialize(stream, data);
        stream.Close();

        OnSave.Invoke();
    }

    public static ShipData Load()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            return data;
        }
        else
        {
            Debug.LogError("Error! File Not Found!");
            return null;
        }
    }

    public static ShipData LoadWithPath(string pPath)
    {
        string path = pPath;
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            return data;
        }
        else
        {
            Debug.LogError("Error! File Not Found!");
            return null;
        }
    }

    public static ShipData[] ReadFiles()
    {
        string[] paths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        List<ShipData> shipDatas = new List<ShipData>(); 

        for (int i = 0; i < paths.Length; i++)
        {
            Debug.Log(paths[i]);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(paths[i], FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            shipDatas.Add(data);

            stream.Close();
        }

        return shipDatas.ToArray();
    }
}
