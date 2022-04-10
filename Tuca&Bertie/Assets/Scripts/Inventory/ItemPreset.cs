using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreset : MonoBehaviour
{

    public List<Item> itemsAccepted = new List<Item>();

    private SpriteRenderer spriteRenderer;

    private Item currentItem;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public bool SetItem(Item i)
    {
        if (itemsAccepted.Contains(i) && currentItem == null)
        {
            //Set the current Item
            currentItem = i;

            //Update Sprite Rengerer
            spriteRenderer.sprite = currentItem.itemSprite;

            return true;

        } else
        {
            Debug.Log("Item Cannot Be Placed Here!");

            return false;
        }
    }
}
