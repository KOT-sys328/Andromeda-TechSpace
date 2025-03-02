using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class SaveData
{
    public string currentSkin;
    public List<string> unlockedSkins;
    public int coins;
    public int highScore;
}

public static class PlayerData
{
    public static string filePath = Path.Combine(Application.persistentDataPath, "Data.json");
    public static string currentSkin;
    public static List<string> unlockedSkins = new List<string>();
    public static int coins;
    public static int highScore;
    public static int score;

    public static string CurentSkin => currentSkin;
    public static List<string> UnlockedSkins => unlockedSkins;
    public static int Coins => coins;
    public static int HighScore => highScore;
    public static int Score => score;

    public static void Save()
    {
        SaveData data = new SaveData
        {
            currentSkin = currentSkin,
            unlockedSkins = new List<string> { },
            coins = coins,
            highScore = highScore
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentSkin = data.currentSkin;
            unlockedSkins = data.unlockedSkins;
            coins = data.coins; 
            highScore = data.highScore;
        }
    }

    public static void ChangeSkin(string skinName)
    {
        currentSkin = skinName;
    }

    public static void AddSkin(string skinName)
    {
        if (!unlockedSkins.Contains(skinName))
        {
            unlockedSkins.Add(skinName);
        }
    }

    public static void AddCoin(int amount)
    {
        coins += amount;
    }

    public static void SetHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}