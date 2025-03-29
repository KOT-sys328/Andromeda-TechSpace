using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<Material> pointerEnterMaterial = new List<Material>();
    [SerializeField] List<GameObject> shopButtonPrefabs;
    [SerializeField] public TextMeshProUGUI buttonText;
    [SerializeField] Button button;

    [SerializeField] public string ButtonName;
    [SerializeField] public bool onBuy = false;
    [SerializeField] public int cost;
    [SerializeField] public int id;

    public Button Button => button;

    private List<Renderer> skinRenderers = new List<Renderer>();
    private Coroutine rotate;
    private Material originMaterial;
    private GameObject model;

    private string name;

    public void Init(SingleSkinSO skin, Action<SingleSkinSO, Action, bool> buyAction, bool isUnlock)
    {
        name = skin.Name;
        onBuy = isUnlock;
        if (isUnlock)
        {
            buttonText.text = $"{skin.name} \n Unlocked";
        } 
        else
        {
            buttonText.text = $"{skin.name} \n cost {skin.Cost}";
        }

        skinRenderers.Clear();
        model = Instantiate(skin.Skin, transform);
        model.GetComponent<RectTransform>().localScale = new Vector3(80, 80, 80);

        skinRenderers = transform.GetChild(2).GetComponentsInChildren<Renderer>().ToList();
        originMaterial = transform.GetChild(2).GetChild(0).GetComponent<Renderer>().material;

        button.onClick.AddListener(() => buyAction?.Invoke(skin, Unlock, onBuy));
    }

    public void Unlock()
    {
        onBuy = true;
        buttonText.text = $"{name} \n Unlocked";
    }

    void OnEnable()
    {
        if (rotate == null)
            rotate = StartCoroutine(Rotate());
    }

    private void OnDisable()
    {
        if (rotate != null)
        {
            StopCoroutine(rotate);
            rotate = null;
        }
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            model.transform.Rotate(new Vector3((model.transform.position.x + Time.deltaTime) / 25, (model.transform.position.y + Time.deltaTime) / 25, 0));
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
