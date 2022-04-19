using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Requests", order = 2)]
public class CharacterRequests : ScriptableObject
{
    //Request Name
    public string requestName;

    //Request Description
    public string requestDesc;

    //Request Item
    public Item requestItem;

    //Request Time Limit
    public float requestTimeLimit;

    //Request Character
    public RequestsController.Character charType;

    //Request Completition
    public bool isCompleted = false;
}
