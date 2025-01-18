using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class skinsHolder : ScriptableObject
{
    [SerializeField] private List<GameObject> skins = new List<GameObject>();
    public List<GameObject> Skins => skins;
}
