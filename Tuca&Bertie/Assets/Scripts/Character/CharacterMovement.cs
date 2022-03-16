using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float maxDist;

    public enum CharacterState { Move, Idle };

    public CharacterState cState;

    public Vector2 startPos;
    public Vector2 destPos;

    public bool isDestSet = false;
    public bool isDestReached = false;

    private Rigidbody2D rb;

    public float timer = 0;
    public float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Set Starting Pos
        startPos = transform.position;

        //Set RigidBody Component
        rb = GetComponent<Rigidbody2D>();

        //Create Random Idle Timer
        maxTimer = Random.Range(1.5f, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Switch States 
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
                    destPos = new Vector2(Random.Range(-4.84f, 4.84f), -4.74f);

                    //Destination Set
                    isDestSet = true;
                }

                break;
            case CharacterState.Idle:
                //Check Timer
                if(timer > maxTimer)
                {
                    //Set Flags to False
                    isDestSet = false;
                    isDestReached = false;

                    //Starting Moving Again
                    cState = CharacterState.Move;

                    //Rest Timer
                    timer = 0;
                } else
                {
                    //Add to Timer
                    timer = timer + 1 * Time.deltaTime;
                }

                break;
        }
    }
}
