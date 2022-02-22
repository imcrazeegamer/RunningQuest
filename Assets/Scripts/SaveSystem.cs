using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    static string path = Application.persistentDataPath + "/data.rat";
    static BinaryFormatter formatter = new BinaryFormatter();
    public static void SaveGame(SaveData data)
    {
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SaveData LoadGame()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File Not Found in " + path + ", Creating New One");
            SaveGame(new SaveData());
            return LoadGame();
        }
    }
}


