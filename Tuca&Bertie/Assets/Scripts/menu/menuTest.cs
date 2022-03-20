using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuTest : MonoBehaviour
{
    public GameObject locButton;
    public GameObject menu;
    public GameObject refMid;
    public GameObject returnPos;
    
    void Start()
    {
        //On Start Keep Menu Closed
        menu.SetActive(false);
        
    }

    void Update()
    {
        
    }

    public void unPause()
    {
        //closing the menu from the button causes the menu to go offscreen
        //and the pause button comes back to the screen
        //locButton.transform.position = returnPos.transform.position;
        //pauseButton.transform.position = new Vector2(655, 1239);
        //menu.transform.position = new Vector2(999,999);

        locButton.SetActive(true);

        //Just Set the Button to inactve Instead of moving it far off-screen
        menu.SetActive(false);
    }

    public void onTap()
    {
        //moves the button offscreen and places the menu on the screen
        //locButton.transform.position = new Vector2(999, 999);
        //menu.transform.position = refMid.transform.position;

        menu.SetActive(true);
        locButton.SetActive(false);
    }
}
