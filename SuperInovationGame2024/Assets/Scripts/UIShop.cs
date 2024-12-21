using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIShop : MonoBehaviour {

    public static UI Instance;
    [SerializeField] private Button rightButtom;
    [SerializeField] private Button leftButtom;
    [SerializeField] private Button skinOne;
    [SerializeField] private Button skinTwo;
    [SerializeField] private Button skinThree;
    [SerializeField] private Button skinFour;
    [SerializeField] private List<GameObject> pages;
    [SerializeField] private List<Text> pagesID;
    private int currentPageID = 0;
    private int currentPage = 0;
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
    }
    private void RightScrol() {
        currentPageID += 1;
        print(currentPageID);
        if (currentPageID == 7) { currentPageID = 0; }
        pages[currentPageID].SetActive(true);
        if (currentPageID != 0) { pages[currentPageID - 1].SetActive(false); }
        else { pages[6].SetActive(false); }
        pagesID[currentPageID].text = "+";
        if (currentPageID != 0) { pagesID[currentPageID - 1].text = "-"; }
        else { pagesID[6].text = "-";}
    }
    private void LeftScrol() {
        pages[currentPageID].SetActive(false);
        pagesID[currentPageID].text = "-";
        currentPageID -= 1;
        if (currentPageID == -1) { currentPageID = 6; }
        print(currentPageID);
        pages[currentPageID].SetActive(true);
        pagesID[currentPageID].text = "+";
    }
}
