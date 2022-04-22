using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;

    public float currencyAmount = 100;

    void Update()
    {
        moneyDisplay.text = "$ " + currencyAmount.ToString();
    }   
}
