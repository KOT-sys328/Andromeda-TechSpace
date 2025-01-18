using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button shopButton;
    [SerializeField] GameObject shopMenu;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        shopButton.onClick.AddListener(OpenShop);
        exitButton.onClick.AddListener(Exit);
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenShop()
    {
        shopMenu.SetActive(true);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
