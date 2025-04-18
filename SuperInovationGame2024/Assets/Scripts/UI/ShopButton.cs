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

    [SerializeField] Material selectedMaterial;

    public Button Button => button;

    public List<Renderer> skinRenderers = new List<Renderer>();
    private Coroutine rotate;
    private Material originMaterial;
    private GameObject model;

    private string name;

    public void Init(SingleSkinSO skin, Action<SingleSkinSO, Action, Action, bool> buyAction, bool isUnlock)
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

        button.onClick.AddListener(() => buyAction?.Invoke(skin, Unlock, SetSelected, onBuy));
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
        PaintObject(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PaintObject(true);
    }

    public void PaintObject(bool toOrigin, bool forcePaint = false, bool fromSelect = false)
    {
        if (fromSelect)
        {
            for (int i = 0; i < skinRenderers.Count; i++)
            {
                skinRenderers[i].material = selectedMaterial;
            }
        }
        else if (Shop.selectedButton.skinRenderers != skinRenderers || forcePaint)
        {
            if (toOrigin)
            {
                for (int i = 0; i < skinRenderers.Count; i++)
                {
                    skinRenderers[i].material = originMaterial;
                }
            }
            else
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
        }
    }

    public void SetSelected()
    {
        if (Shop.selectedButton != null)
        {
            Shop.selectedButton.PaintObject(true, true);
        }
        Shop.selectedButton = this;
        PaintObject(false, true, true);
    }
}
