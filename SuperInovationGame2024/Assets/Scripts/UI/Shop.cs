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

    public static ShopButton selectedButton;
    public void Init()
    {
        ShopButton first = new ShopButton();
        buttonExit.onClick.AddListener(() => Close());

        for (int i = 0; i < 6; i++)
        {
            bool unlock = CheckUnlock(_skinsHolder.Skins[i]);
            ShopButton shopButton = Instantiate(shopButtonPrefabs, content);
            shopButton.Init(skin.Skins[i], BuySkin, unlock);
            if (i == 0)
                first = shopButton;
            if (_skinsHolder.Skins[i].Name == PlayerData.CurentSkin)
            {
                shopButton.SetSelected();
            }
        }
        if (selectedButton == null)
        {
            first.SetSelected();
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

    public void BuySkin(SingleSkinSO skin, Action unlockAction, Action selectedAction, bool unlock)
    {
        if (unlock)
        {
            PlayerData.ChangeSkin(skin.name);
            selectedAction.Invoke();
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
