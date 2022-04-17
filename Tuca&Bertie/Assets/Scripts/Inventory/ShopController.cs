using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    //List of ALL avalibale Shop Items
    public List<Item> shopItems = new List<Item>();

    public GameObject buttonPrefab;

    public Transform btnParent;

    public int money = 100;

    public Sprite tenSprite, twentySprite, thirtySprite;



    private void Start()
    {
        for(int i = 0; i <= shopItems.Count - 1; i++)
        {
            GameObject goButton = Instantiate(buttonPrefab);
            goButton.transform.SetParent(btnParent, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();

            goButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = shopItems[i].itemSprite;

            switch (shopItems[i].itemPrice)
            {
                case 10:
                    goButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = tenSprite;
                    break;
                case 20:
                    goButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = twentySprite;
                    break;
                case 30:
                    goButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = thirtySprite;
                    break;
            }

            int a = i;

            tempButton.GetComponent<Button>().onClick.AddListener(delegate { PurchaseItem(shopItems[a]); });
        }


    }

    public void PurchaseItem(Item item)
    {
        Debug.Log(item.itemName);

        if (money >= item.itemPrice)
        {

            //Remove Amount from Currency
            money -= item.itemPrice;

            if (item.itemType == Item.ItemType.Item)
            {
                //Placeable Item
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(item);

            } else if(item.itemType == Item.ItemType.Room)
            {
                //Room Unlocker

                GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");


                //Loop through each room
                for (int i = 0; i <= rooms.Length - 1; i++)
                {
                    //Check if Room ID matches
                    if(rooms[i].GetComponent<RoomLocker>().roomID == item.roomID)
                    {
                        if (rooms[i].GetComponent<RoomLocker>().isRoomUnlocked == true)
                        {
                            Debug.Log($"Room:  {rooms[i].name } already Unlocked!");
                            return;
                        }
                        //Unlock Room
                        rooms[i].GetComponent<RoomLocker>().isRoomUnlocked = true;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not Enough Money!");
        }
    }
}
