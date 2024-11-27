using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
