using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    string playerName;

    int highScore;
    string bestPlayerName;

    private void Awake()
    {
        if (Instance != null) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SetPlayerName(string name)
    {
        playerName = name;

        if (bestPlayerName == null)
        {
            bestPlayerName = playerName;
            highScore = 0;
        }
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetHighScore(int score)
    {
        highScore = score;
        bestPlayerName = playerName;
        SaveData();
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public string GetBestScoreText()
    {
        return "Best Score: " + bestPlayerName + ": " + highScore;
    }

    [System.Serializable]
    class HighScore

    {
        public int Score;
        public string PlayerName;
    }
    public void SaveData()
    {
        HighScore data = new HighScore();
        data.Score = highScore;
        data.PlayerName = bestPlayerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);
            bestPlayerName = data.PlayerName;
            highScore = data.Score;
        }
    }
}
