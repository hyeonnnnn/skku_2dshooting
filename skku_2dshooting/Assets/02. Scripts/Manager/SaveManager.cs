using UnityEngine;

public static class SaveManager
{
    private const string SaveKey = "SaveDataKey";

    public static void Save(int score)
    {
        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public static SaveData Load()
    {
        if( PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data;
        }
        return null;
    }
}
