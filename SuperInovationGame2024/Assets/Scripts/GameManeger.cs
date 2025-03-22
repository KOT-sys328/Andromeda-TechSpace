using UnityEngine;

public class GameManeger : MonoBehaviour
{
    private void Awake()
    {
        PlayerData.Load();
    }
}
