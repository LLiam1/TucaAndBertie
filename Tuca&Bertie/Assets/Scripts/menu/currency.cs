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
}
