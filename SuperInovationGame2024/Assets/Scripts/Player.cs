using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    private RectTransform rect;
    private int layerMask = 7;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            rect.position = hit.point;
        }
    }
}