using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Material pointerMaterial;
    [SerializeField] GameObject shop;
    [SerializeField] Button buttonExit;
    [SerializeField] ShopButton shopButtonPrefabs;
    [SerializeField] Transform content;
    [SerializeField] skinsHolder skin;
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
            var shopButton = Instantiate(shopButtonPrefabs, content);
            shopButton.Init(i, pointerMaterial);
        }
    }
}
