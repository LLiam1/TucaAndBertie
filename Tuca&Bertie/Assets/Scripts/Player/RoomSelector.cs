using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : MonoBehaviour
{
    //Selected Room...
    public GameObject selectedRoom;

    //Input Touch Position
    private Vector3 touchPosWorld;

    //Camera Start Position
    public Transform startPos;

    //Camera Target Position
    private Transform targetPos;

    //Camera Current Pos
    private Transform currentPos;

    //Camera Object
    public Camera cam;

    public float orthographicTargetSize = 1.189422f;

    //Float: Normal Orthographic Size
    private float orthographicNormalSize = 5f;

    public float smooth;

    public float ogSmooth;

    public GameObject mainCanvas;

    public bool isSelectorActive;

    public Vector3 camStartPos;

    public RequestsController.Character character;

    private void Start()
    {
        //Set Starting Camera Position
        startPos = cam.transform;
    }

    public void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Transform Touch to World Point
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //Put Touch X&Y into Vector2
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //Layer Mask
            int roomsMask = LayerMask.GetMask("Rooms");
 
            //Shoot RayCast
             RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, roomsMask);

            //Check what it collides with
            if (hit.collider != null)
            {
                if (selectedRoom != null || isSelectorActive == false)
                {
                    return;
                }

                if (hit.collider.gameObject.GetComponent<RoomLocker>().isRoomUnlocked)
                {
                    //We should have hit something with a 2D Physics collider!
                    selectedRoom = hit.transform.gameObject;

                    targetPos = selectedRoom.transform;

                    isSelectorActive = false;

                    //touchedObject should be the object someone touched.
                    Debug.Log("GameObject Touched: " + selectedRoom.transform.name);
                }
            }
        }
        else
        {
            currentPos = cam.transform;
        }

        if (selectedRoom != null)
        {
            targetPos = selectedRoom.transform;
        }


        if (selectedRoom != null)
        {
            targetPos = selectedRoom.transform;

            if (Vector3.Distance(cam.transform.position, targetPos.position) > 1f)
            {
                cam.transform.position = Vector3.Lerp(startPos.transform.position,
                    new Vector3(targetPos.transform.position.x, targetPos.transform.position.y, -10f), Time.deltaTime * smooth);


                if (cam.orthographicSize >= 1.8f)
                {
                    cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, orthographicTargetSize, Time.deltaTime * ogSmooth);
                }
            }


            mainCanvas.GetComponent<UIController>().DisplayGoBackButton(true);
        }
        else
        {
            if (Vector3.Distance(cam.transform.position, camStartPos) > 0.0001f)
            {
                cam.transform.position = Vector3.Lerp(currentPos.transform.position,
                    camStartPos, Time.deltaTime * smooth);
            }

            if (cam.orthographicSize <= 5f)
            {
                cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, 5f, Time.deltaTime * ogSmooth);

                cam.orthographicSize = orthographicNormalSize;
            }

            mainCanvas.GetComponent<UIController>().DisplayGoBackButton(false);
        }

    }

    public void RemoveSelectedRoom()
    {
        selectedRoom = null;

        isSelectorActive = true;
    }


}
