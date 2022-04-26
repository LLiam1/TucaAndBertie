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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ShowLock(isRoomUnlocked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Transform Touch to World Point
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //Put Touch X&Y into Vector2
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //Layer Mask
            int layerMask = LayerMask.GetMask("Rooms");

            //Shoot RayCast
            RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, layerMask);

            //Check what it collides with
            if (hit.collider != null)
            {
                Debug.Log($"{hit.collider.gameObject.name}");

                if (hit.collider.gameObject.tag == "Room" && hit.collider.gameObject.GetComponent<RoomLocker>().isRoomUnlocked == false)
                {
                    hit.collider.gameObject.GetComponent<RoomLocker>().PurchaseRoom(hit.collider.gameObject.GetComponent<RoomLocker>().roomData);
                }
            }
        }

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

    public void PurchaseRoom(Item roomData)
    {
        UIController ui = mainCanvas.GetComponent<UIController>();

        ui.buyConfrimText.text = "Would you like to purchase " + roomData.itemName + " for $ " + roomData.itemPrice + "?";

        ui.DisplayConfirmBuyMenu();

        ui.confirmBuyBtn.GetComponent<Button>().onClick.AddListener(
            delegate {
                ui.confirmBuyBtn.interactable = false;
                CompeletePurchase(roomData);
            });
    }

    public void CompeletePurchase(Item item)
    {
        currency player = GameObject.FindGameObjectWithTag("Player").GetComponent<currency>();

        if (player.currencyAmount >= item.itemPrice)
        {

            //Remove Amount from Currency
            player.currencyAmount -= item.itemPrice;

            Debug.Log($"Purchase Sucess! Currency { player.currencyAmount }");


            GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");


            //Loop through each room
            for (int i = 0; i <= rooms.Length - 1; i++)
            {
                //Check if Room ID matches
                if (rooms[i].GetComponent<RoomLocker>().roomID == item.roomID)
                {
                    if (rooms[i].GetComponent<RoomLocker>().isRoomUnlocked == true)
                    {
                        Debug.Log($"Room:  {rooms[i].name } already Unlocked!");
                        return;
                    }
                    //Unlock Room
                    rooms[i].GetComponent<RoomLocker>().isRoomUnlocked = true;

                    rooms[i].GetComponent<RoomLocker>().ShowLock(true);

                }
            }
        }
        else {
            Debug.Log("You do not have enough money!");
        }

        mainCanvas.GetComponent<UIController>().roomBuyConfirmMenu.SetActive(false);
    }
}
