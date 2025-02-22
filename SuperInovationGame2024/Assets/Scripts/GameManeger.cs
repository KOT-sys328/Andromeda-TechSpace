using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    private void Awake()
    {
        PlyerData.Load();
    }
}
