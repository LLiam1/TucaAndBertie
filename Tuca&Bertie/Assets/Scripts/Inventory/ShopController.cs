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

    public GameObject shopMenu;

    private void Start()
    {
        for(int i = 0; i <= shopItems.Count - 1; i++)
        {
            GameObject goButton = Instantiate(buttonPrefab);
            goButton.transform.SetParent(btnParent, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();

            goButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = shopItems[i].itemSprite;

            int a = i;

            tempButton.GetComponent<Button>().onClick.AddListener(delegate { PurchaseItem(shopItems[a]); });


        }
    }

    public void ShopOpen()
    {
        shopMenu.SetActive(true);
    }


    public void ShopClose()
    {
        shopMenu.SetActive(false);
    }


    public void PurchaseItem(Item item)
    {

        currency curr = GameObject.FindGameObjectWithTag("Player").GetComponent<currency>();

        if (curr.money >= item.itemPrice)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(item);

            curr.money -= item.itemPrice;
        }
        else
        {
            Debug.Log("Not Enough Money!");
        }
    }
}
