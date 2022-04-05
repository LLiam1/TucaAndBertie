using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    //List of Players Inventory Items
    public List<Item> inventoryItems = new List<Item>();

    public TextMeshProUGUI inventoryList;


    public GameObject inventoryUI;

    private void Start()
    {
        CloseInventory();
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);



        //Disable Room Selector
        GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;


        DisplayInventory();
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);


        GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;
    }

    public void DisplayInventory()
    {
        //Start off Empty
        inventoryList.text = "";

        foreach(Item i in inventoryItems)
        {
            inventoryList.text += i.name + "\n";
        }

    }


    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }
}
