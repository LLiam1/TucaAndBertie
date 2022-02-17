using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : MonoBehaviour
{
    //Selected Room...
    public GameObject selectedRoom;

    //Input Touch Position
    private Vector3 touchPosWorld;

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

                //touchedObject should be the object someone touched.
                Debug.Log("GameObject Touched: " + selectedRoom.transform.name);
            }
        }


        //TODO: Zoom Camera In ON Selected Room

    }


}
