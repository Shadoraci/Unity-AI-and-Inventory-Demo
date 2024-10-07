using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int ItemID; 
    public string ItemName;
    public int Value;
    public Sprite Icon;
    public ItemType itemType;
    public int Quantity = 0;

    private void OnDisable()
    {
        Quantity = 1;
    }

    public enum ItemType
    {
        Potion, 
        Misc,
        Knife,
        Pistol,
        DMR,
        LMG,
        Shotgun,
        Raygun,
        Nukegun
    }
}
