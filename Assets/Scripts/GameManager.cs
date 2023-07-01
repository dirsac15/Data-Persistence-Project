using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string CurrentPlayerName;
    public string HighScorePlayerName;
    public long HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public string HighScorePlayerName;
        public long HighScore;
    }

    public void SaveHighScore()
    {
        var saveData = new SaveData();
        saveData.HighScorePlayerName = CurrentPlayerName;
        saveData.HighScore = HighScore;

        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadHighScore()
    {
        var path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }
}
