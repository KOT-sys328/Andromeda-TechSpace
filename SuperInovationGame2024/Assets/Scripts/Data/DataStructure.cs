using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [System.Serializable]
    public class DataStructure : MonoBehaviour
    {
        public int maxScore;
        public int money;
        public List<Text> skinsPurchased;
    }
}