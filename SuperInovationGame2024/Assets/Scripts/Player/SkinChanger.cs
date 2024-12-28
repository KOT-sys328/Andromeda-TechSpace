using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private ModelSO modelSO;
    private void Awake()
    {
        var modelId = PlayerPrefs.GetInt(ConstHolder.SKIN);
        Instantiate(modelSO.Models[modelId], transform);
    }
}
