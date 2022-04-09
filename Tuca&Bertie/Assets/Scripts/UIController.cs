using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject shopMenu;

    public GameObject goBackBtn;

    private void Start()
    {
        //Disable Menu's on Start
        shopMenu.SetActive(false);
        inventoryMenu.SetActive(false);
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
}
