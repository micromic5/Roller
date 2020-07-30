using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/data.pige";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void saveData(SaveData saveData)
    {
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveData loadData()
    {
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData saveData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return saveData;
        }
        else
        {
            SaveData data = new SaveData(0,AudioToggle.ON,IntroToggle.ON);
            saveData(data);
            return data;
        }
    }
}
