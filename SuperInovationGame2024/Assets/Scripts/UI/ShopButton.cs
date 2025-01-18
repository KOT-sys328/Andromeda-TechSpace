using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;
    void Start()
    {
        //button.onClick.AddListener();
    }

    public void Init(int num)
    {
        buttonText.text = $"skin {num + 1}";
        button.onClick.AddListener(() => PlyerData.ChangeSkin(num));
    }
}
