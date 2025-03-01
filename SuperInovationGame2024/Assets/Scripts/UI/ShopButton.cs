using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] List<GameObject> shopButtonPrefabs;
    [SerializeField] public TextMeshProUGUI buttonText;
    [SerializeField] Button button;

    [SerializeField] public string ButtonName;
    [SerializeField] public bool onBuy = false;
    [SerializeField] public int cost;
    [SerializeField] public int id;

    [SerializeField] TextMeshProUGUI costText;

    public Button Button => button;

    private List<Material> pointerEnterMaterial = new List<Material>();
    private List<Renderer> skinRenderers = new List<Renderer>();
    private RectTransform model;
    private Coroutine rotate;
    private Material originMaterial;

    public void Init(SingleSkinSO skin, int num)
    {
        skinRenderers.Clear();
        button.onClick.AddListener(() => PlayerData.ChangeSkin(skin.name));
        var model = Instantiate(skin.Skin, transform);
        model.GetComponent<RectTransform>().localScale = new Vector3(80, 80, 80);

        skinRenderers = transform.GetChild(2).GetComponentsInChildren<Renderer>().ToList();

        originMaterial = transform.GetChild(2).GetChild(0).GetComponent<Renderer>().material;

        PlayerData.SetDataOnButton(num, gameObject);

        buttonText.text = $"{skin.name} \n cost {skin.Cost}";

    }

    void OnEnable()
    {
        if (rotate == null)
            rotate = StartCoroutine(Rotate(model));
    }

    private void OnDisable()
    {
        if (rotate != null)
        {
            StopCoroutine(rotate);
            rotate = null;
        }
    }

    IEnumerator Rotate(RectTransform model)
    {
        while (true)
        {
            model.Rotate(new Vector3((model.transform.position.x + Time.deltaTime) / 25, (model.transform.position.y + Time.deltaTime) / 25, 0));
            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < skinRenderers.Count; i++)
        {
            if (onBuy)
            {
                skinRenderers[i].material = pointerEnterMaterial[0];
            }
            else
            {
                skinRenderers[i].material = pointerEnterMaterial[1];
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < skinRenderers.Count; i++)
        {
            skinRenderers[i].material = originMaterial;
        }
    }
}
