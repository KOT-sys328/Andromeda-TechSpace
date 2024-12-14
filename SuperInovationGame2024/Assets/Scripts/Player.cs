using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthMax;
    [SerializeField] float speed;
    [SerializeField] float speedMiddle;
    [SerializeField] float speedMax;
    [SerializeField] float SpeedMin;
    [SerializeField] int immortality;

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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            rect.position = new Vector3(hit.point.x, 0, hit.point.z);
        }

        if (immortality > 0)  
        {
            InvokeRepeating("OnImmortality", 1, 1);   
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Death();
    }
    void Death()
    {
        if (immortality <= 0)
        {
            immortality = 5;
            health--;
            speed = speedMiddle;
            rect.position = new Vector3(0, 0, 0);

            Debug.Log("Reset immortality: " + immortality);
            Debug.Log("Health: " + health);

            if (health <= 0)
            {
                //Destroy(gameObject);
            }
        }
    }
    void OnImmortality()
    {
        if (immortality > 0)
        {
            immortality -= 1;
            Debug.Log("Immortality: " + immortality);
        }
    }
}