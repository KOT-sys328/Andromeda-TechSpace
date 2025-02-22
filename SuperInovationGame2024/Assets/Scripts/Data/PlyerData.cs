using UnityEngine;

public static class PlyerData
{
    public static string[] nameButtons = { "imba", "square", "bomb", "iron", "gen", "okey" };
    public static bool[]   buySkins    = { true,   false,     false, false,  false, false  };
    public static int[]    costButtons = { 10,     10,        20,    30,     10,    5      };

    private static int money;
    public static int Money => money;

    private static int skinNum;
    public static int SkinNum => skinNum;
    private static int score;
    public static int Score => score;
    private static int maxScore;
    public static int MaxScore => maxScore;

    public static void Save()
    {
        PlayerPrefs.SetInt("max score", skinNum);
        PlayerPrefs.SetInt("skinNum",   skinNum);
        PlayerPrefs.SetInt("score",     score);
        PlayerPrefs.SetInt("money",     maxScore);
    }

    public static void Load()
    {
        skinNum  = PlayerPrefs.GetInt("skinNum");
        money    = PlayerPrefs.GetInt("money");
        score    = PlayerPrefs.GetInt("score");
        maxScore = PlayerPrefs.GetInt("max score");
    }

    public static void ChangeSkin(int num, GameObject shopbutton)
    {
        skinNum = num;
    }

    public static void SetDataOnButton(int num, GameObject button)
    {
        button.GetComponent<ShopButton>().ButtonName = nameButtons[num];
        button.GetComponent<ShopButton>().cost = costButtons[num];
        button.GetComponent<ShopButton>().onBuy = buySkins[num];
    }

    public static void AddMoney(int cost) { 
        money += cost;
        PlayerPrefs.SetInt("money", money);
    }
    public static void MinusMoney(int cost) { 
        money -= cost;
        PlayerPrefs.SetInt("money", money);
    }
    public static void AddScore(int add_score) 
    {
        score += add_score;
        PlayerPrefs.SetInt("score", score);
    }
    public static void MinusScore(int minus_score)
    {
        score -= minus_score;
        PlayerPrefs.SetInt("score", score);
    }
    public static void saveMaxScore(int max_score)
    {
        maxScore = max_score;
        PlayerPrefs.SetInt("max score", maxScore);
    }
}
