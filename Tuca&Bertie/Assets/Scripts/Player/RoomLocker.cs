using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLocker : MonoBehaviour
{

    public bool isRoomUnlocked = false;

    public GameObject unlockRoomPrefab;

    public Sprite lockedSprite;

    private SpriteRenderer spriteRenderer;

    public int roomID;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoomUnlocked)
        {
            spriteRenderer.sprite = null;
        } else
        {
            spriteRenderer.sprite = lockedSprite;
        }
    }

    public void DisplayBuyMenu()
    {
        //TODO Instantiate Menu Object to Buy Room
    }
}
