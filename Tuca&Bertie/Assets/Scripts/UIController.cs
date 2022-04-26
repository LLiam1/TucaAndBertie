using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject shopMenu;

    public GameObject goBackBtn;

    public GameObject roomBuyConfirmMenu;

    public TextMeshProUGUI buyConfrimText;

    public Button confirmBuyBtn;

    private void Start()
    {
        //Disable Menu's on Start
        shopMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        roomBuyConfirmMenu.SetActive(false);
    }

    private void Update()
    {
        if(shopMenu.activeSelf || inventoryMenu.activeSelf || roomBuyConfirmMenu.activeSelf)
        {
            //Disable RoomSelector
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;
        } else
        {
            //Enable RoomSelector
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;
        }
    }


    public void DisplayShopMenu()
    {
        if (inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);
        }

        shopMenu.SetActive(!shopMenu.activeSelf);

        if (shopMenu.activeSelf)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;
        }
        else {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;
        }
    }

    public void DisplayInventoryMenu()
    {
        if (shopMenu.activeSelf)
        {
            shopMenu.SetActive(false);
        }

        inventoryMenu.SetActive(!inventoryMenu.activeSelf);

        //Disable Touching Other Rooms
        if (inventoryMenu.activeSelf)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;
        }
    }

    public void DisplayGoBackButton(bool active)
    {
        goBackBtn.SetActive(active);
    }

    public void DisplayConfirmBuyMenu()
    {
        if (roomBuyConfirmMenu.activeSelf)
        {
            roomBuyConfirmMenu.SetActive(false);
        }

        roomBuyConfirmMenu.SetActive(!roomBuyConfirmMenu.activeSelf);

        if (roomBuyConfirmMenu.activeSelf)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>().isSelectorActive = true;
        }
    }
}
