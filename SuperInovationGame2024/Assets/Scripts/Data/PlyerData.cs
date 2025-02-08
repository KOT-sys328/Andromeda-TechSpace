using UnityEngine;

public static class PlyerData
{
    public static string[] nameButtons = { "imba", "square", "bomb", "iron", "gen", "okey" };
    public static bool[] buySkins = { false, false, false, false, false, false };
    public static int[] costButtons = {10, 10, 20, 30, 10, 5};

    private static int money;
    public static int Money => money;

    private static int skinNum;
    public static int SkinNum => skinNum;

    public static void Save()
    {
        PlayerPrefs.SetInt("skinNum", skinNum);
        PlayerPrefs.SetInt("money", money);
    }

    public static void Load()
    {
        skinNum = PlayerPrefs.GetInt("skinNum");
        money = PlayerPrefs.GetInt("money");
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

    public static void AddMoney(int cost) { money += cost; }
    public static void MinusMoney(int cost) { money -= cost; }
}
