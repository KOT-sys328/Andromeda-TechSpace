using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] Button buttonExit;
    [SerializeField] ShopButton shopButtonPrefabs;
    [SerializeField] Transform content;
    [SerializeField] skinsHolder skin;
    void Start()
    {
        buttonExit.onClick.AddListener(() => Close());  

        for (int i = 0; i < skin.Skins.Count; i++)
        {
            var shopButton = Instantiate(shopButtonPrefabs, content);
            shopButton.Init(i);
        }
    }

    void Close()
    {
        shop.SetActive(false);
        PlyerData.Save();
    }
}
