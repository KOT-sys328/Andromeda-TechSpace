using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class skinsHolder : ScriptableObject
{
    [SerializeField] private List<SingleSkinSO> skins = new List<SingleSkinSO>();
    public List<SingleSkinSO> Skins => skins;

    public int FindNumByName(string name)
    {
        foreach (var skin in Skins)
        {
            if (skin.name == name)
            {
                return Skins.IndexOf(skin);
            }
        }
        return -1;
    }
}
