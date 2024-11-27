using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    void Start()
    {
    }
    void Update()
    {
        transform.position = Input.mousePosition;

    }
}
