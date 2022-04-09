using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject shopMenu;

    private void Start()
    {
        //Disable Menu's on Start
        shopMenu.SetActive(false);
        inventoryMenu.SetActive(false);
    }


    public void DisplayShopMenu()
    {
        shopMenu.SetActive(!shopMenu.activeSelf);
    }

    public void DisplayInventoryMenu()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeSelf);
    }
}
