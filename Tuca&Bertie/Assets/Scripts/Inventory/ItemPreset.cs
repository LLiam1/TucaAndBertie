using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreset : MonoBehaviour
{

    public List<Item> itemsAccepted = new List<Item>();

    private SpriteRenderer spriteRenderer;

    private Item currentItem;

    public PlayerInventory playerInventory;

    bool activated;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (PlayerInventory.itemSelected == itemsAccepted[0])
        {
            spriteRenderer.color = Color.yellow;
        } else if (!activated)
        {
            spriteRenderer.color = Color.black;
        }
    }

    public bool SetItem(Item i)
    {
        if (itemsAccepted.Contains(i) && currentItem == null)
        {
            //Set the current Item
            currentItem = i;

            //Update Sprite Rengerer
            spriteRenderer.sprite = currentItem.itemSprite;

            spriteRenderer.color = Color.white;

            activated = true;
            return true;

        } else
        {
            Debug.Log("Item Cannot Be Placed Here!");

            return false;
        }
    }
}
