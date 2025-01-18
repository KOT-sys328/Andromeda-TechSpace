using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI : MonoBehaviour {

    public static UI Instance;
    [SerializeField] private Button startButtom;
    [SerializeField] private Button resumeButtom;
    [SerializeField] private Button restartButtom;
    [SerializeField] private Button shopButtom;
    [SerializeField] private Button settingsButtom;
    [SerializeField] private Button exitShopButtom;
    [SerializeField] private Button exitSettingsButtom;
    [SerializeField] private Button exitButtom;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject shopScreen;

    void Start() 
    {
        Time.timeScale = 0;
        loadScreen.SetActive(false);
        Instance = this;
        menu.SetActive(false);
        OnClickBottom();
    }
    private void Update() 
    {
        OnClickEscape();
        
    }

    public void StartTime() { Time.timeScale = 1; startButtom.gameObject.SetActive(false); }
    public void showMenu(bool byDeath) 
    {
        if (menu.activeSelf == true) { return; }
        resumeButtom.gameObject.SetActive(!byDeath);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    private void OnClickEscape() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            showMenu(false);
            shopScreen.SetActive(false);
            settingsScreen.SetActive(false);
        }
    }
    private void OnClickBottom() 
    {
        startButtom.onClick.AddListener(StartTime);
        resumeButtom.onClick.AddListener(Resume);
        restartButtom.onClick.AddListener(Restart);
        settingsButtom.onClick.AddListener(Settings);
        exitSettingsButtom.onClick.AddListener(ExitSettings);
        exitButtom.onClick.AddListener(Exit);
    }
    private void Resume() 
    {
        StartTime();
        menu.SetActive(false);     
    }

    private void Restart()
    {
        loadScreen.SetActive(true);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        StartTime();
    }

    private void Settings() { settingsScreen.SetActive(true); }
    private void ExitSettings()
    { 
        settingsScreen.SetActive(false);
    }
    private void Exit() 
    {
        loadScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }

}
