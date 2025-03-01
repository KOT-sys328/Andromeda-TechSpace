using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    ShopButton _ShopButton = new ShopButton();
    [SerializeField] List<Material> pointerMaterial = new List<Material>();
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] skinsHolder skin;
    [SerializeField] ShopButton shopButtonPrefabs;
    [SerializeField] GameObject shop;
    [SerializeField] Transform content;
    [SerializeField] Button buttonExit;
    [SerializeField] Button shopButton;
    public void Init()
    {
        buttonExit.onClick.AddListener(() => Close());

        for (int i = 0; i < 6; i++)
        {
            _ShopButton.Init(skin.Skins[i], i);
        }
    }

    void Close()
    {
        shop.SetActive(false);
        PlayerData.Save();
    
    }

    void BuyButton(GameObject button)
    {
        int cost = button.GetComponent<ShopButton>().cost;
        if (PlayerData.Coins > cost)
        {
            PlayerData.MinusMoney(cost);
            button.GetComponent<ShopButton>().buttonText.text = $"Skin {button.GetComponent<ShopButton>().id}";
        }
    }
}
