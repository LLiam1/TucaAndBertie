using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector2 : MonoBehaviour
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

    //Orthographic Target Size
    public float orthographicTargetSize = 2.25f;

    //Normal Orthographic Size
    private float orthographicNormalSize = 5f;

    public float smooth;

    public GameObject mainCanvas;

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

            //Shoot RayCast
            RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            //Check what it collides with
            if (hit.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                selectedRoom = hit.transform.gameObject;

                targetPos = selectedRoom.transform;

                //touchedObject should be the object someone touched.
                Debug.Log("GameObject Touched: " + selectedRoom.transform.name);
            }
        } else
        {
            currentPos = cam.transform;
        }

        if(selectedRoom != null)
        {
            targetPos = selectedRoom.transform;
        }


        //TODO: Zoom Camera In ON Selected Room

        if (selectedRoom != null)
        {
            if (Vector3.Distance(cam.transform.position, targetPos.position) > 1f)
            {
                cam.transform.position = Vector3.MoveTowards(startPos.transform.position,
                    new Vector3(targetPos.transform.position.x, targetPos.transform.position.y, -10f), Time.deltaTime * smooth);

                //if (orthographicNormalSize - orthographicTargetSize > 0.25f)
                //{
                //    cam.orthographicSize = Mathf.Lerp(orthographicNormalSize, orthographicTargetSize, Time.deltaTime * 5f);
                //}

                cam.orthographicSize = orthographicTargetSize;

                mainCanvas.GetComponent<UIController>().DisplayGoBackButton(false);
            } 
        } else
        {
            cam.transform.position = Vector3.MoveTowards(currentPos.transform.position,
                   startPos.transform.position, Time.deltaTime * smooth);

            cam.orthographicSize = orthographicNormalSize;


            mainCanvas.GetComponent<UIController>().DisplayGoBackButton(true);
        }

    }

    public void RemoveSelectedRoom()
    {
        selectedRoom = null;
    }


}
