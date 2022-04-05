using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyProduction : MonoBehaviour
{
    public currency refCash;

    public int charCap;
    private int charHolding;
    public int charRate;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        refCash.money += charHolding;
    }

    public void deposit()
    {
        refCash.money += charHolding;
    }

    IEnumerator makeMoney()
    {
        yield return new WaitForSeconds(2);
        charHolding += charRate;
    }
}
