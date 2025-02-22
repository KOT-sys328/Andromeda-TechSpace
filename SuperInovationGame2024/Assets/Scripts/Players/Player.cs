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
    float timer;
    bool onDeath = false;
    RectTransform rect;
    Canvas canvas;
    Collider coll;
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore");
        rect = GetComponent<RectTransform>();
        PlyerData.Load();
        var model = Instantiate(skinsHolder.Skins[PlyerData.SkinNum], rect);
        canvas = GetComponentInParent<Canvas>();
        coll = model.GetComponent<Collider>();
        scoreText.text = "Score: " + score.ToString();
        maxScoreText.text = "Max score: " + maxScore.ToString();
        moneyText.text = "Money: " + PlyerData.Money.ToString();
    }
    void Update()
    {
        if (Time.timeScale < 0.1) return;
        MoveForMouse();
        OnDeath();
        Score();
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            timer = 0;
            PlyerData.AddMoney(1);
        }
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
            if (collision.gameObject.name == "Coin_1(Clone)") { PlyerData.AddMoney(1);  }
            if (collision.gameObject.name == "Coin_2(Clone)") { PlyerData.AddMoney(5);  }
            if (collision.gameObject.name == "Coin_3(Clone)") { PlyerData.AddMoney(10); }
            Destroy(collision.gameObject);
        }
    }

    private void OnDeath() 
    {
        if (onDeath && timerOnDeath > 0.0f) { timerOnDeath -= Time.deltaTime; }
        if (timerOnDeath <= 0.0f)
        {
            PlyerData.Save();
            coll.isTrigger = false;
            onDeath = false;
            timerOnDeath = 0.0f;
        }
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
}