using UnityEngine;

public class SaveManager
{
    private const string SaveKey = "SaveDataKey";

    public void Save(int score)
    {
        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();

        Debug.Log($"{json} 저장 완료");
    }

    public SaveData Load()
    {
        if( PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            Debug.Log($"{data} 로드 완료");
            
            return data;
        }
        return null;
    }
}
