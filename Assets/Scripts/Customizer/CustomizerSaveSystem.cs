using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CustomizerSaveSystem
{
    public static void Save(CustomizerSelector selector)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shipData.getoutofhere";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipData data = new ShipData(selector);

        formatter.Serialize(stream, data);
        stream.Close();
    }
}
