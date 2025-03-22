using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Toggle godMode;
    [SerializeField] Toggle x5Mode;
    [SerializeField] Toggle hardMode;
    [SerializeField] Toggle normalMode;
    [SerializeField] Toggle easyMode;
    [SerializeField] Text maxScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text moneyText;
    public bool onGodMode;
    public bool onx5Mode;
    public bool onHardMode;
    public bool onNormalMode;
    public bool onEasyMode;
    private void Start()
    {
        scoreText.text    = "Score: "     + PlayerData.Score.ToString();
        maxScoreText.text = "Max score: " + PlayerData.HighScore.ToString();
        moneyText.text    = "Money: "     + PlayerData.Coins.ToString();
    }
    private void Update()
    {
        if (Time.timeScale < 0.1f)
        {
            onGodMode    = godMode.isOn;
            onx5Mode     = x5Mode.isOn;
            onHardMode   = hardMode.isOn;
            onNormalMode = normalMode.isOn;
            onEasyMode   = easyMode.isOn;
        }
    }
    public void UpdateText()
    {
        scoreText.text    = "Score: "     + PlayerData.Score.ToString();
        maxScoreText.text = "Max score: " + PlayerData.HighScore.ToString();
        moneyText.text    = "Money: "     + PlayerData.Coins.ToString();
    }
}
