using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button shopButton;
    [SerializeField] Shop shopMenu;
    [SerializeField] GameObject shop;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);

        shopMenu.Init();
        shopButton.onClick.AddListener(OpenShop);
        exitButton.onClick.AddListener(Exit);
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenShop()
    {
        shop.SetActive(true);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
