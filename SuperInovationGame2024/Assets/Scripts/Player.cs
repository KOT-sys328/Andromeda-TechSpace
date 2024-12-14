using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool onDeath = false;
    private float timerOnDeath = 0.0f;
    private BoxCollider coll;
    private Vector3 originPos;
    private Quaternion originRot;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        coll = GetComponent<BoxCollider>();
        originPos = rect.localPosition;
        originRot = rect.localRotation;
    }
    void Update()
    {
        if (Time.timeScale < 0.1) return;
        MoveForMouse();
        OnDeath();
    }
    private void MoveForMouse() {

        RectTransformUtility.ScreenPointToLocalPointInRectangle (
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );
        rect.localPosition = new Vector3(localPoint.x, localPoint.y, rect.localPosition.z);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == dangerLayer && onDeath != true) {
            UI.Instance.showMenu(true);
            timerOnDeath = 3;
            onDeath = true;
        }
    }

    private void OnDeath() {
        if (onDeath && timerOnDeath > 0.0f) { timerOnDeath -= Time.deltaTime; }
        if (timerOnDeath <= 0.0f) {
            coll.isTrigger = false;
            onDeath = false;
            timerOnDeath = 0.0f;
        }
    }

    private void ToOriginPos() {
        coll.isTrigger = true;
        rb.velocity = Vector3.zero;
        rect.localPosition = originPos;
        rect.localRotation = originRot;
    }
}