using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int health;
    [SerializeField] float speed;
    private const int dangerLayer = 9;
    private RectTransform rect;
    private Canvas canvas;
    private float timerOnDeath = 0;
    public static int onDeath = 0;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    void Update()
    {
        MoveForMouse();
        if (timerOnDeath > 0.0f) { timerOnDeath -= Time.deltaTime; }
    }
    private void MoveForMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        rect.localPosition = localPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == dangerLayer && timerOnDeath <= 0.0f) 
        { 
            UI.Instance.StopTime();
            //audioSource.play();
            timerOnDeath = 3;
        }
    }

}