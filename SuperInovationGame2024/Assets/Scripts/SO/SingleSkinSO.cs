using UnityEngine;

[CreateAssetMenu]
public class SingleSkinSO : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] GameObject visual;
    [SerializeField] float cost;
    public string Name => name;
    public GameObject Skin => visual;
    public float Cost => cost;
}
