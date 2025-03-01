using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class ShopMoneyText : MonoBehaviour
{
    [SerializeField] GameObject shopMoneyText;
    private void Update()
    {
        shopMoneyText.GetComponent<TextMeshProUGUI>().text = $"Money {PlayerData.Coins.ToString()}";
    }
}
