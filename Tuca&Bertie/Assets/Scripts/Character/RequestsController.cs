using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestsController : MonoBehaviour
{
    //List of Request for Tuca
    public List<CharacterRequests> tucaRequests = new List<CharacterRequests>();

    //List of Requests for Bertie
    public List<CharacterRequests> bertieRequests = new List<CharacterRequests>();

    //List of Request for any Character
    public List<CharacterRequests> generalRequests = new List<CharacterRequests>();

    //Keep track of Completed Requests
    private List<CharacterRequests> completedRequests = new List<CharacterRequests>();

    //TODO ADD Other Charcter in Game Lists... and Requests...

    public enum Character
    {
        General,
        Tuca,
        Bertie,
    }


    //This Function will Set a Requests to the Character in the Room
    public CharacterRequests SetRequest(Character ch)
    {
        //Random Number between 0 and 1
        int rand = Random.Range(0, 1);

        CharacterRequests rq = null;

        //0 = General Request | 1 = Character Specific Requests
        if(rand == 0)
        {
            //General Request
            rq = generalRequests[0];
        } else
        {
            //Specific Character Reequest
            switch (ch)
            {
                case Character.General:
                    rq = generalRequests[0];
                    break;
                case Character.Tuca:
                    rq = tucaRequests[0];
                    break;
                case Character.Bertie:
                    rq = bertieRequests[0];
                    break;
            }
        }

        //Return Requests
        return rq;
    }

    //Call this to Remove Request when Request Completed
    public void RemoveRequest(CharacterRequests rq, Character ch)
    {
        completedRequests.Add(rq);

        switch (ch)
        {
            case Character.General:
                generalRequests.Remove(rq);
                break;
            case Character.Tuca:
                tucaRequests.Remove(rq);
                break;
            case Character.Bertie:
                bertieRequests.Remove(rq);
                break;
        }
    }
}
