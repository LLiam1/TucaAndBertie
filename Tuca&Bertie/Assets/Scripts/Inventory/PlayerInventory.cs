using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    //List of Players Inventory Items
    public List<Item> inventoryItems = new List<Item>();

    public TextMeshProUGUI inventoryList;


    public GameObject inventoryUI;

    public GameObject itemPrefab;

    public GameObject inventoryParent;

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
        //inventoryList.text = "";

        foreach(Item i in inventoryItems)
        {
            //inventoryList.text += i.name + "\n";


            GameObject invItem = Instantiate(itemPrefab);
            invItem.transform.SetParent(inventoryParent.transform, false);
            invItem.transform.localScale = new Vector3(1, 1, 1);


            invItem.gameObject.GetComponent<Image>().sprite = i.itemSprite;
        }

    }


    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }
}
