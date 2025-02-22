using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class skinsHolder : ScriptableObject
{
    [SerializeField] private List<SingleSkinSO> skins = new List<SingleSkinSO>();
    public List<SingleSkinSO> Skins => skins;
}
