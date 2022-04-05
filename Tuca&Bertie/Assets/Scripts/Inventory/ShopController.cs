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

    public void test(int i)
    {
        Debug.Log(i);
    }

    public void PurchaseItem(Item item)
    {
        Debug.Log(item.itemName);

        if (money >= item.itemPrice)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(item);

            money -= item.itemPrice;
        }
        else
        {
            Debug.Log("Not Enough Money!");
        }
    }
}
