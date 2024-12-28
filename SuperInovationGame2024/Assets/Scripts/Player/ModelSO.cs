using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ModelSO : ScriptableObject
{
    [SerializeField] private List<GameObject> models = new List<GameObject>();
    public List<GameObject> Models => models;
}
