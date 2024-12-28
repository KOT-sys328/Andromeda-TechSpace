using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using Core;

public class withJSON : MonoBehaviour
{
    private UIShop _UIShop = new UIShop();
    private Player _Player = new Player();
    private DataStructure _DataStructure = new DataStructure();

    private void Start()
    {
        _DataStructure.maxScore = _Player.maxScore;
        _DataStructure.money = _Player.money;
        _DataStructure.skinsPurchased = _UIShop.skinsPurchased;
        print(_DataStructure.skinsPurchased.Count);
        print(_DataStructure.maxScore);
        print(_DataStructure.money);
    }

    public void SaveData()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Data.json");
        for (int i = 0; i < 3; i++)
        {
            string json = JsonUtility.ToJson(_DataStructure);
            sw.WriteLine(json);
            print(json);
        }
        sw.Close();
        print("Saved");
    }

    private void LoadData()
    {
        string[] readed = File.ReadAllLines(Application.persistentDataPath + "/Data.json");
        if (readed.Length < 5) { return; }
        List<Text> SkinsPurchased = new List<Text>();
        for (int i = 0; i < readed.Length; i++)
        {
            _DataStructure = JsonUtility.FromJson<DataStructure>(readed[i]);
            SkinsPurchased.Add(_DataStructure.skinsPurchased[i]);
        }
        _UIShop.skinsPurchased = SkinsPurchased;
        print("Loaded");
    }
}
