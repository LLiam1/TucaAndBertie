using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Float: Movement Speed
    public float moveSpeed;

    //Float: Max Distance (Player to Destination Position)
    public float maxDist;

    //Float: Idle Timer
    public float idleTimer = 0;

    //Float: Max Time to Idle for
    public float maxIdleTime;

    //Enum: Keep Track of Character State (Moving or Idling)
    public enum CharacterState { Move, Idle };

    //CharacterState: Current Starte of the Character
    public CharacterState cState;

    //Vector2: Keep Track of Starting Position
    public Vector2 startPos;

    //Vector2: Keep Track of Destination Position
    public Vector2 destPos;

    //Bool: To Check if Destination is Set.
    public bool isDestSet = false;

    //Bool: To Check if Destination is Reached.
    public bool isDestReached = false;

    //Rigidbody2D: Component on GameObject
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Set Starting Pos
        startPos = transform.position;

        //Set RigidBody Component
        rb = GetComponent<Rigidbody2D>();

        //Create Random Idle Timer
        maxIdleTime = Random.Range(1.5f, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Switch Between States 
        switch (cState)
        {
            case CharacterState.Move:

                //Check if Destination is Set & If it is not Set generate a positon
                if (isDestSet)
                {
                    //Check Distance
                    if (Vector2.Distance(transform.position, destPos) > maxDist)
                    {
                        Vector3 move;
                        if (destPos.x < transform.position.x)
                        {
                            //Create Force
                             move = new Vector3(-moveSpeed, transform.position.y);
                             rb.MovePosition(transform.position + move);
                        } else if(destPos.x > transform.position.x)
                        {
                            //Create Force
                            move = new Vector3(moveSpeed, transform.position.y);
                            rb.MovePosition(transform.position + move);
                        }

                        //Destination Still not Reached
                        isDestReached = false;
                    }
                    else
                    {
                        //Destination Reached
                        isDestReached = true;

                        //Change State
                        cState = CharacterState.Idle;
                    }
                } else
                {
                    //Random X Pos
                    destPos = new Vector2(Random.Range(-7f, 7f), -4.74f);

                    //Destination Set
                    isDestSet = true;
                }

                break;
            case CharacterState.Idle:
                //Check Timer
                if(idleTimer > maxIdleTime)
                {
                    //Set Flags to False
                    isDestSet = false;
                    isDestReached = false;

                    //Starting Moving Again
                    cState = CharacterState.Move;

                    //Rest Timer
                    idleTimer = 0;
                } else
                {
                    //Add to Timer
                    idleTimer = idleTimer + 1 * Time.deltaTime;
                }

                break;
        }
    }
}
