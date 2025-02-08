using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
    public void Init()
    {
        buttonExit.onClick.AddListener(() => Close());
        shopButton.onClick.AddListener(ShopButton);

        ShopButton();
    }

    void Close()
    {
        shop.SetActive(false);
        PlyerData.Save();
    }

    void ShopButton()
    {
        if (content.childCount > 0) return;

        for (int i = 0; i < skin.Skins.Count; i++)
        {
            var _shopButton = Instantiate(shopButtonPrefabs, content);
            _shopButton.Init(i, pointerMaterial);
            _shopButton.GetComponent<ShopButton>().id = i;
            shopButton.onClick.AddListener(() => BuyButton(_shopButton.gameObject));
        }
    }

    void BuyButton(GameObject button)
    {
        int cost = button.GetComponent<ShopButton>().cost;
        if (PlyerData.Money > cost)
        {
            PlyerData.MinusMoney(cost);
            button.GetComponent<ShopButton>().buttonText.text = $"Skin {button.GetComponent<ShopButton>().id}";
        }
    }
}
