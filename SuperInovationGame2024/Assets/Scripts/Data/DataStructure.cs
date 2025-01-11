using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataStructure : MonoBehaviour
{
    public int maxScore;
    public int money;
    public List<Text> skinsPurchased;
    public static DataStructure Instance;

    private void Awake()
    {
        Instance = this;
    }
}