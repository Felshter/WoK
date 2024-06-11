using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string savePath => Application.persistentDataPath + "/savefile.json";

    public static void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved");
    }

    public static SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found");
            return null;
        }
    }

    public static bool SaveFileExists()
    {
        return File.Exists(savePath);
    }
}
