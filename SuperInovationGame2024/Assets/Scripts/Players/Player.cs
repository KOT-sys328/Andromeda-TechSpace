using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public Text moneyText;
    [SerializeField] skinsHolder skinsHolder;
    [SerializeField] Text maxScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] float speed;
    public float scoreTimer;
    public float moneyTimer;
    public int maxScore = 0;
    public int score = 0;
    const int dangerLayer = 9;
    const int coinLayer = 10;
    float timerOnDeath = 0.0f;
    bool onDeath = false;
    int money = PlyerData.Money;
    RectTransform rect;
    Canvas canvas;
    Collider coll;
    Rigidbody rb;
    Vector3 originPos;
    Quaternion originRot;
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        maxScore = PlayerPrefs.GetInt("maxScore");
        rect = GetComponent<RectTransform>();
        PlyerData.Load();
        var model = Instantiate(skinsHolder.Skins[PlyerData.SkinNum], rect);
        rb = GetComponent<Rigidbody>();
        canvas = GetComponentInParent<Canvas>();
        coll = model.GetComponent<Collider>();
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
    private void MoveForMouse() 
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle (
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );
        rect.localPosition = new Vector3(localPoint.x, localPoint.y, 0);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.layer == dangerLayer && onDeath != true)
        {
            if (maxScore < score) { maxScore = score; score = 0; }
            UI.Instance.showMenu(true);
            timerOnDeath = 3;
            onDeath = true;
        }
        if (collision.gameObject.layer == coinLayer && onDeath != true)
        {
            if (collision.gameObject.name == "Coin_1(Clone)")
            {
                AddMoney(1);
            }
            if (collision.gameObject.name == "Coin_2(Clone)")
            {
                AddMoney(5);
            }
            if (collision.gameObject.name == "Coin_3(Clone)")
            {
                AddMoney(10);
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnDeath() 
    {
        if (onDeath && timerOnDeath > 0.0f) { timerOnDeath -= Time.deltaTime; }
        if (timerOnDeath <= 0.0f)
        {
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("maxScore", maxScore);
            coll.isTrigger = false;
            onDeath = false;
            timerOnDeath = 0.0f;
        }
    }
    private void ToOriginPos() 
    {
        coll.isTrigger = true;
        rb.velocity = Vector3.zero;
        rect.localPosition = originPos;
        rect.localRotation = originRot;
    }

    public void Score() 
    {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 1.0f) {
            scoreTimer = 0.0f;
            score++;
            scoreText.text = "Score: " + score.ToString();
            maxScoreText.text = "Max score: " + maxScore.ToString();
        }
    }

    private void Money(int multiplier) 
    {
        moneyTimer += Time.deltaTime;
        if (moneyTimer >= 5) {
            money += 1 * multiplier;
            moneyText.text = "Money: " + money.ToString();
            moneyTimer = 0.0f;
        }
    }
    public void AddMoney(int multiplier) 
    { 
        money += 1 * multiplier; 
        moneyText.text = "Money: " + money.ToString();
    }
}