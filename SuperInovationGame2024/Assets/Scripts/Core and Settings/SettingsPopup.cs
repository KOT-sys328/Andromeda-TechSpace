using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private ModelSO models;
    public void SetSkin(int id)
    {
        PlayerPrefs.SetInt("skin", id);
    }
}
