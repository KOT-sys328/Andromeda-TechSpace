using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.HID;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text maxScoreText;
    [SerializeField] float speed;
    public int score;
    public static int maxScore = 0;
    public float scoreTimer;
    public float moneyTimer;
    public static int money = 0;
    private const int dangerLayer = 9;
    private bool onDeath = false;
    private float timerOnDeath = 0.0f;
    private RectTransform rect;
    private Canvas canvas;
    private BoxCollider coll;
    private Rigidbody rb;
    private Vector3 originPos;
    private Quaternion originRot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        coll = GetComponent<BoxCollider>();
        originPos = rect.localPosition;
        originRot = rect.localRotation;
        scoreText.text = "Score: " + score.ToString();
        maxScoreText.text = "Max score: " + maxScore.ToString();
        moneyText.text = "Money: " + money.ToString();
    }
    void Update()
    {
        if (Time.timeScale < 0.1) return;
        MoveForMouse();
        OnDeath();
        Score();
        Money(1);
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
            if (maxScore < score) { maxScore = score; score = 0; }
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

    public void Score() {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 1.0f) {
            scoreTimer = 0.0f;
            score++;
            scoreText.text = "Score: " + score.ToString();
            maxScoreText.text = "Max score: " + maxScore.ToString();
        }
    }

    private void Money(int multiplier) {
        moneyTimer += Time.deltaTime;
        if (moneyTimer >= 5) {
            money += 1 * multiplier;
            moneyText.text = "Money: " + money.ToString();
            moneyTimer = 0.0f;
        }
    }
    public void AddMoney(int multiplier) { 
        money += 1 * multiplier; 
        moneyText.text = "Money: " + money.ToString();
    }
}