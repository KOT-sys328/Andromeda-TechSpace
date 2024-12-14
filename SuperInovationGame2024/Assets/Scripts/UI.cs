using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;
    [SerializeField] private Button startButtom;
    [SerializeField] private Button slowButtom;
    [SerializeField] private Button speedButtom;
    [SerializeField] private Button superSpeedButtom;
    private float timeSpeed;
    void Start()
    {
        Instance = this;
        timeSpeed = 1;
        StopTime();
        startButtom.onClick.AddListener(StartTime);
        slowButtom.onClick.AddListener(() => ChangeTimeSpeed(0.75f));
        speedButtom.onClick.AddListener(() => ChangeTimeSpeed(1.25f));
        superSpeedButtom.onClick.AddListener(() => ChangeTimeSpeed(2f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (Time.timeScale < 0.2) { StartTime(); }
            else { StopTime(); }
        }
    }
    public void StartTime() { Time.timeScale = timeSpeed; startButtom.gameObject.SetActive(false); }
    public void StopTime() { Time.timeScale = 0; startButtom.gameObject.SetActive(true); }
    public void ChangeTimeSpeed(float speed) { timeSpeed = speed; Time.timeScale = timeSpeed; } 
}
