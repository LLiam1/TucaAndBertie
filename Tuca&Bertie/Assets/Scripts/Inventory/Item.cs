using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    //String: Item Name
    public string itemName;

    //String: Item Description
    public string itemDesc;

    //Int: Item Price
    public int itemPrice;

    //Sprite: Item Sprite
    public Sprite itemSprite;

    //Item Type
    public enum ItemType { Item, Room };

    //ItemType
    public ItemType itemType;

    //Room ID To Unlock
    public int roomID;
}

