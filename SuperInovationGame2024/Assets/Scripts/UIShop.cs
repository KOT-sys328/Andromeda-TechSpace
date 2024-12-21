using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.Data.SqlTypes;
using Palmmedia.ReportGenerator.Core.Common;

public class UIShop : MonoBehaviour {

    public static UI Instance;
    [SerializeField] private Button rightButtom;
    [SerializeField] private Button leftButtom;
    [SerializeField] private List<Text> pagesID;
    [SerializeField] private List<Text> skinsPurchased;
    [SerializeField] private List<Button> skins;
    [SerializeField] private List<GameObject> pages;
    [SerializeField] private List<GameObject> skinsPrefabs;
    private int currentPageID = 0;
    void Start() 
    {
        OnClickBottom();
    }
    private void Update() 
    {

    }

    private void OnClickBottom()
    {
        rightButtom.onClick.AddListener(RightScrol);
        leftButtom.onClick.AddListener(LeftScrol);
        for (int i = 0; i < skins.Count; i++) 
        {
            int id = i;
            skins[id].onClick.AddListener(() => SkinsBuyOrChoise(id));
        }
    }
    private void RightScrol()
    {
        currentPageID += 1;
        if (currentPageID == 7) { currentPageID = 0; }
        pages[currentPageID].SetActive(true);
        if (currentPageID != 0) { pages[currentPageID - 1].SetActive(false); }
        else { pages[6].SetActive(false); }
        pagesID[currentPageID].text = "+";
        if (currentPageID != 0) { pagesID[currentPageID - 1].text = "-"; }
        else { pagesID[6].text = "-";}
    }
    private void LeftScrol()
    {
        pages[currentPageID].SetActive(false);
        pagesID[currentPageID].text = "-";
        currentPageID -= 1;
        if (currentPageID == -1) { currentPageID = 6; }
        pages[currentPageID].SetActive(true);
        pagesID[currentPageID].text = "+";
    }

    private void SkinsBuyOrChoise(int id)
    {
        if (!skinsPurchased[id].text.Contains("purchased")) 
        {
            if (Player.money >= int.Parse(skinsPurchased[id].text.Split(" ")[0]))
            {
                Player.money -= int.Parse(skinsPurchased[id].text.Split(" ")[0]);
                skinsPurchased[id].text = "purchased";
            }
        }
        else 
        {
            skinsPrefabs[id].SetActive(true);
            for (int i = 0; i < skins.Count; i++)
            {
                if (i != id)
                {
                    skinsPrefabs[i].SetActive(false);
                }
            }
        }
    }
}
