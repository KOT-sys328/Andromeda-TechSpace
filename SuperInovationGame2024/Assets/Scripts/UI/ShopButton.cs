using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] List<GameObject> shopButtonPrefabs;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Button button;

    private RectTransform model;
    private Coroutine rotate;
    private List<Renderer> skinRenderers = new List<Renderer>();
    private Material pointerEnterMaterial;
    private Material originMaterial;

    public void Init(int num, Material material)
    {
        skinRenderers.Clear();
        buttonText.text = $"skin {num + 1}";
        button.onClick.AddListener(() => PlyerData.ChangeSkin(num));
        model = Instantiate(shopButtonPrefabs[num], transform).GetComponent<RectTransform>();
        model.localScale = new Vector3(80, 80, 80);

        skinRenderers = transform.GetChild(2).GetComponentsInChildren<Renderer>().ToList();

        pointerEnterMaterial = material;
        originMaterial = transform.GetChild(2).GetChild(0).GetComponent<Renderer>().material;
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
            skinRenderers[i].material = pointerEnterMaterial;
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
