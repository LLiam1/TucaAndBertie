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

    public List<GameObject> listItemButtons = new List<GameObject>();

    public Item itemSelected;

    public GameObject mainCanvas;


    private void Start()
    {
        CloseInventory();
    }

    private void Update()
    {
        //Check if Item is Selected
        if (itemSelected != null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Transform Touch to World Point
                Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //Put Touch X&Y into Vector2
                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //Shoot RayCast
                RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                //Check what it collides with
                if (hit.collider != null)
                {
                    if(hit.collider.gameObject.tag == "PresetItemPlacement")
                    {
                        //Touched on PlaceHolder Item
                        Debug.Log($"Item Selected: {itemSelected} ");

                        if (hit.collider.gameObject.GetComponent<ItemPreset>().SetItem(itemSelected))
                        { 
                            //Remove From Inventory
                            RemoveItem(itemSelected);

                            itemSelected = null;
                        }
                    }
                }
            }
        }
    }


    public void OpenInventory()
    {
        //Disable Room Selector
        GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;

        DisplayInventory();
    }

    public void CloseInventory()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;

    }

    public void DisplayInventory()
    {
        foreach (GameObject obj in listItemButtons)
        {
            Destroy(obj);
        }

        listItemButtons.Clear();


        foreach (Item i in inventoryItems)
        {
            GameObject goButton = Instantiate(itemPrefab);
            goButton.transform.SetParent(inventoryUI.transform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();

            goButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = i.itemSprite;

            listItemButtons.Add(goButton);

            tempButton.GetComponent<Button>().onClick.AddListener(
                delegate {
                    PlaceItem(i);
                });

        }

    }


    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);      
    }



    public void PlaceItem(Item item)
    {
        //Set Item Selected
        itemSelected = item;


        //Close Inventory
        mainCanvas.GetComponent<UIController>().DisplayInventoryMenu();


        //Debug.Log("Inventory Item Selected!");
    }
}
