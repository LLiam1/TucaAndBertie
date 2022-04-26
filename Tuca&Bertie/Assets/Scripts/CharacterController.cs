using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private RequestsController requestsController;
    private RoomSelector roomSelector;
    private PlayerInventory playerInventory;
    private UIController uiController;

    public CharacterRequests currentRequest;

    public enum Character
    {
        General,
        Tuca,
        Bertie,
    }

    public RequestsController.Character currentCharacter;

    public bool isDialogueDone = false;

    public GameObject dialoguePrefab;

    // Start is called before the first frame update
    void Start()
    {
        requestsController = GameObject.FindGameObjectWithTag("RequestController").GetComponent<RequestsController>();
        roomSelector = GameObject.FindGameObjectWithTag("Player").GetComponent<RoomSelector>();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

        //Start off with a Request
        requestsController.SetRequest(currentCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        if (roomSelector.isSelectorActive && playerInventory.itemSelected == null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Transform Touch to World Point
                Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //Put Touch X&Y into Vector2
                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //Layer Mask
                int layerMask = LayerMask.GetMask("Character");

                //Shoot RayCast
                RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, layerMask);

                //Check what it collides with
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Character")
                    {
                        if (isDialogueDone == false)
                        {
                            if (dialoguePrefab != null)
                            {
                                DisplayDialogue();

                                isDialogueDone = true;
                            }
                        }
                        else
                        {
                            DisplayRequestDialogue();
                        }

                    }
                }
            }
        }
    }

    public void DisplayDialogue()
    {
        uiController.dialogue.SetActive(true);

        //TODO Display Introduction Dialog
        GameObject dialogue = Instantiate(dialoguePrefab, transform.position, Quaternion.identity);

        roomSelector.RemoveSelectedRoom();
    }

    public void DisplayRequestDialogue()
    {
        //TODO Display Happiness Meter
    }
}
