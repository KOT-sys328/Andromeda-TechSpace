using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JsonS : MonoBehaviour
{
    public string SavePath;
    SaveDataToJsonD data = new SaveDataToJsonD();
    Player player = new Player();

    UIShop _UIShop = new UIShop();
    void Start()
    {
        SavePath = Application.persistentDataPath + "/data.json";

        if (File.Exists(SavePath))
        {
            string fileData = File.ReadAllText(SavePath);
            SaveDataToJsonD data = JsonUtility.FromJson<SaveDataToJsonD>(fileData);

            _UIShop.skinsPurchased = data.skinsPurchased.ToList();
            player.maxScore = data.maxScore;
            Player.money = data.money;
        }
    }

    public void Save()
    {
        data.money = Player.money;
        data.maxScore = player.maxScore;
        data.skinsPurchased = _UIShop.skinsPurchased;

        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, jsonString);
    }
}

public class SaveDataToJsonD
{
    public List<Text> skinsPurchased;
    public int maxScore;
    public int money;
}