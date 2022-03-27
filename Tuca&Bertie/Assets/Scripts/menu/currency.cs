using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public TextMeshProUGUI output;

    public int money = 100;

    public int itemPrice;

    string nameT;

    void Start()
    {
        switch (nameT)
        {
            case "table":
                {
                    itemPrice = 10;
                    break;
                }
            case "test20":
                {
                    itemPrice = 20;
                    break;
                }
            case "test30":
                {
                    itemPrice = 30;
                    break;
                }
        }
    }

    void Update()
    {
        output.text = money.ToString();
    }

    public void onPurchase(string itemName)
    {
        nameT = itemName;
        money -= itemPrice;
    }

    public void PurchaseItem(Item item)
    {
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
