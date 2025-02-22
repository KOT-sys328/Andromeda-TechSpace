using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerUI _PlayerUI;
    [SerializeField] skinsHolder skinsHolder;
    [SerializeField] float speed;
    public float scoreTimer;
    public float moneyTimer;
    public bool onDeath = false;
    const int dangerLayer = 9;
    const int coinLayer = 10;
    float timerOnDeath = 0.0f;
    float timer;
    RectTransform rect;
    Canvas canvas;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        var model = Instantiate(skinsHolder.Skins[PlyerData.SkinNum], rect);
        canvas = GetComponentInParent<Canvas>();
    }
    void Update()
    {
        if (Time.timeScale < 0.1) return; 
        MoveForMouse();
        OnDeath();
        Score();
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            PlyerData.AddMoney(1);
            _PlayerUI.UpdateText();
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
            if (_PlayerUI.onGodMode) return;
            if (PlyerData.MaxScore < PlyerData.Score) 
            {
                PlyerData.saveMaxScore(PlyerData.Score); 
                PlyerData.MinusScore(PlyerData.Score); 
            }
            UI.Instance.showMenu(true);
            timerOnDeath = 3;
            onDeath = true;
        }
        if (collision.gameObject.layer == coinLayer && onDeath != true)
        {
            if (collision.gameObject.name == "Coin_1(Clone)") 
            { 
                PlyerData.AddMoney(1);
                _PlayerUI.UpdateText();
            }
            if (collision.gameObject.name == "Coin_2(Clone)") 
            { 
                PlyerData.AddMoney(5);
                _PlayerUI.UpdateText();
            }
            if (collision.gameObject.name == "Coin_3(Clone)") 
            { 
                PlyerData.AddMoney(10);
                _PlayerUI.UpdateText();
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnDeath() 
    {
        if (_PlayerUI.onGodMode) return;
        if (onDeath && timerOnDeath > 0.0f) timerOnDeath -= Time.deltaTime;
        if (timerOnDeath <= 0.0f)
        {
            PlyerData.Save();
            onDeath = false;
            timerOnDeath = 0.0f;
        }
    }

    public void Score() 
    {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 1.0f) 
        {
            scoreTimer = 0.0f;
            PlyerData.AddMoney(1);
            _PlayerUI.UpdateText();
        }
    }
}