using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    public static UI Instance;
    private float timeSpeed;
    [SerializeField] private Button startButtom;
    [SerializeField] private Button resumeButtom;
    [SerializeField] private Button restartButtom;
    [SerializeField] private Button exitButtom;
    [SerializeField] private Button slowButtom;
    [SerializeField] private Button speedButtom;
    [SerializeField] private Button superSpeedButtom;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadScreen;

    void Start() 
    {
        loadScreen.SetActive(false);
        Instance = this;
        timeSpeed = 1;
        menu.SetActive(false);
        OnClickBottom();
    }
    private void Update() 
    {
        OnClickEnter();
    }

    public void StartTime() { Time.timeScale = timeSpeed; startButtom.gameObject.SetActive(false); }
    public void ChangeTimeSpeed(float speed) { timeSpeed = speed; Time.timeScale = timeSpeed; }
    public void showMenu(bool byDeath) {
        if (menu.activeSelf == true) { return; }
        resumeButtom.gameObject.SetActive(!byDeath);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    private void OnClickEnter() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            showMenu(false);
        }
    }
    private void OnClickBottom() {
        startButtom.onClick.AddListener(StartTime);
        resumeButtom.onClick.AddListener(Resume);
        restartButtom.onClick.AddListener(Restart);
        exitButtom.onClick.AddListener(Exit);
        slowButtom.onClick.AddListener(() => ChangeTimeSpeed(0.75f));
        speedButtom.onClick.AddListener(() => ChangeTimeSpeed(1.25f));
        superSpeedButtom.onClick.AddListener(() => ChangeTimeSpeed(2f));
    }
    private void Resume() {
        StartTime();
        menu.SetActive(false);
    }
    private void Restart() {
        loadScreen.SetActive(true);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    private void Exit() {
        loadScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
