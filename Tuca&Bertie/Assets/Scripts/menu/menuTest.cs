using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuTest : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject menu;
    public GameObject refMid;
    public GameObject pauseLoc;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void unPause()
    {
        pauseButton.transform.position = pauseLoc.transform.position;
        //pauseButton.transform.position = new Vector2(655, 1239);
        menu.transform.position = new Vector2(999,999);
    }

    public void onTap()
    {
        pauseButton.transform.position = new Vector2(999, 999);
        menu.transform.position = refMid.transform.position;
    }
}
