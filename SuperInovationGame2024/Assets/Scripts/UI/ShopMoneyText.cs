using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class ShopMoneyText : MonoBehaviour
{
    [SerializeField] GameObject shopMoneyText;
    private void OnEnable()
    {
        shopMoneyText.GetComponent<TextMeshProUGUI>().text = $"Money {PlayerPrefs.GetInt("money").ToString()}";
    }
}
