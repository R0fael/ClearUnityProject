using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "Item", menuName = "OXO Engine/Item")]
public class Item : ScriptableObject
{
    [Header("In Development...")]
    public new string name = "Empty Item";
    public string[]? tags;
    public int amount = 1;
    [Range(1, 256)]
    public int maxAmount = 64;
    public Dictionary<string, object> data;
    public GameObject drop;
}
