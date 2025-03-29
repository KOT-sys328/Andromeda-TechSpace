using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Material> pointerMaterial = new List<Material>();
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] skinsHolder skin;
    [SerializeField] ShopButton shopButtonPrefabs;
    [SerializeField] GameObject shop;
    [SerializeField] Transform content;
    [SerializeField] Button buttonExit;
    [SerializeField] Button shopButton;

    [SerializeField] private skinsHolder _skinsHolder;
    public void Init()
    {
        buttonExit.onClick.AddListener(() => Close());

        for (int i = 0; i < 6; i++)
        {
            bool unlock = CheckUnlock(_skinsHolder.Skins[i]);
            ShopButton shopButton = Instantiate(shopButtonPrefabs, content);
            shopButton.Init(skin.Skins[i], BuySkin, unlock);
        }
    }

    private bool CheckUnlock(SingleSkinSO skin)
    {
        return PlayerData.UnlockedSkins.Contains(skin.name);
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
            PlayerData.SubCoin(cost);
            button.GetComponent<ShopButton>().buttonText.text = $"Skin {button.GetComponent<ShopButton>().id}";
        }
    }

    public void BuySkin(SingleSkinSO skin, Action unlockAction, bool unlock)
    {
        if (unlock)
        {
            PlayerData.ChangeSkin(skin.name);
        }
        else
        {
            if (PlayerData.Coins >= skin.Cost)
            {
                PlayerData.SubCoin(skin.Cost);
                PlayerData.ChangeSkin(skin.name);
                unlockAction.Invoke();
            }
        }
    }
}
