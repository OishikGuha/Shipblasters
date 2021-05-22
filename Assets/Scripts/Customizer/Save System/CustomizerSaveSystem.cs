using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CustomizerSaveSystem
{

    public static string fileName = "shipData.getoutofhere";

    public static void Save(CustomizerSelector selector)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + fileName;
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipData data = new ShipData(selector);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShipData Load()
    {
        string path = Application.persistentDataPath + "/" + fileName;
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
}
