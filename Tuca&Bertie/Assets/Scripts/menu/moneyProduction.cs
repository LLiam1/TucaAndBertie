using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyProduction : MonoBehaviour
{
    public currency refCash;

    public int charCap;
    private float charHolding;
    public float charRate;

    public happinessMeter happinessGauge;
    public int isHappy;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("currency: " + refCash.money);
        if (charHolding >= charCap)
        {
            charHolding = charCap;
            StopCoroutine(makeMoney());
        }
        else
        {
            StartCoroutine(makeMoney());
        }

    }

    //test doesnt work
    public void OnTriggerEnter2D(Collider2D collision)
    {
        refCash.money += charHolding;
    }


    //allows the user to gain the money
    public void deposit()
    {
        refCash.money += charHolding;
    }

    //creates the currency for the character
    IEnumerator makeMoney()
    {
        yield return new WaitForSeconds(2);

        if (happinessGauge.happiness <= isHappy)
        {
            charRate = charRate * .75f;
        }
        else
        {
            charRate = charRate * 1.33f;
        }

        charHolding += charRate;
    }
}
