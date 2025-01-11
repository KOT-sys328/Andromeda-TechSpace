using System.IO;
using UnityEngine;

public static class withJSON
{

    public static void SaveData()
    {
        string dataPath = Application.persistentDataPath + "/Data.json";
        DataStructure.Instance.money = Player.Instance.money;
        DataStructure.Instance.maxScore = Player.Instance.maxScore;
        DataStructure.Instance.skinsPurchased = UIShop.Instance.skinsPurchased;

        Debug.Log(DataStructure.Instance);
        Debug.Log(Player.Instance.money);
        Debug.Log(Player.Instance.maxScore);
        Debug.Log(UIShop.Instance.skinsPurchased);
        Debug.Log(dataPath);

        string jsonString = JsonUtility.ToJson(DataStructure.Instance);
        File.WriteAllText(dataPath, jsonString);
    }

    public static void LoadData()
    {
        string dataPath = Application.persistentDataPath + "/Data.json";

        if (File.Exists(dataPath))
        {
            string fileData = File.ReadAllText(dataPath);
            DataStructure data = JsonUtility.FromJson<DataStructure>(fileData);

            UIShop.Instance.skinsPurchased = data.skinsPurchased;
            Player.Instance.maxScore = data.maxScore;
            Player.Instance.money = data.money;

            Debug.Log(DataStructure.Instance);
            Debug.Log(Player.Instance.money);
            Debug.Log(Player.Instance.maxScore);
            Debug.Log(UIShop.Instance.skinsPurchased);
        }
    }
}
