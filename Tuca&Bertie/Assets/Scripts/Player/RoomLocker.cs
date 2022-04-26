using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomLocker : MonoBehaviour
{

    public bool isRoomUnlocked = false;

    public GameObject roomLock;

    private SpriteRenderer spriteRenderer;

    public int roomID;

    public Item roomData;

    public GameObject mainCanvas;

    public RequestsController.Character character;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        ShowLock(isRoomUnlocked);
    }

    // Update is called once per frame
    void Update()
    {
   

    }

    private void ShowLock(bool islock)
    {
        if (islock)
        {
            roomLock.SetActive(false);
        } else {

            roomLock.SetActive(true);
        }
    }
}
