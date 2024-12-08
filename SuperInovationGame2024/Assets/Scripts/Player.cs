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
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    void Update()
    {
        MoveForMouse();
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
        if (collision.gameObject.layer == dangerLayer ) 
        { 
            UI.Instance.StopTime();
        }
    }
}