using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class animationDialogue : MonoBehaviour
{
    //text to indicate character and dialogue
    public TextMeshProUGUI text;
    public TextMeshProUGUI whosTalking;

    //dialogue
    public string[] sentences;

    //first character: animation and resting
    public string charOne;
    public GameObject talk;
    public GameObject notTalking;

    //second character: animation and resting
    public string charTwo;
    public GameObject talk2;
    public GameObject notTalking2;

    //which sentence in dialogue
    private int index;

    //screen positions
    private Vector3 offScreen1 = new Vector3(7.0f, 0.52f, 0.0f);
    private Vector3 offScreen2 = new Vector3(-7.0f, 0.52f, 0.0f);
    private Vector3 onScreen = new Vector3(0.0f, 0.52f, 0.0f);

    //animation timer
    private float time = 1.5f;
    private void Awake()
    {
        //wipes dialogue text
        text.text = "";
    }

    void Start()
    {
        whosTalking.text = charOne;
        StartCoroutine(Type());
    }


    void Update()
    {
        //check to see if its the end of the sentence
        if (text.text == sentences[index])
        {
            //check which sentence to see who was talking
            if (index % 2 == 0)
            {
                //toggle off first character animation for resting face
                talk.SetActive(false);
                notTalking.SetActive(true);
            }
            else
            {
                //toggle off second character animation for resting face
                talk2.SetActive(false);
                notTalking2.SetActive(true);
            }

            if (Input.GetMouseButton(0))
            {
                if (index == sentences.Length - 1)
                {
                    SceneManager.LoadScene("SampleScene");
                }

                //start next sentence
                NextSentence();
            }
        }
    }

    IEnumerator Type()
    {
        yield return new WaitForSeconds(time);

        //type effect
        foreach (char letters in sentences[index].ToCharArray())
        {
            //check which sentence to see who was talking
            if (index % 2 == 0)
            {
                //change character box
                whosTalking.text = charOne;

                //handle talking and not talking animations
                notTalking.SetActive(false);
                talk.SetActive(true);

                talk2.SetActive(false);
            }
            else
            {
                //change character box
                whosTalking.text = charTwo;

                //handle talking and not talking animations
                notTalking2.SetActive(false);
                talk2.SetActive(true);
                
                talk.SetActive(false);
            }
            text.text += letters;
            yield return new WaitForSeconds(.02f);

        }
    }

    //swap character animations
    IEnumerator SwapCharacter(GameObject character, Vector3 targetPosition, float duration)
    {
       float time = 0;
       Vector3 startPos = character.transform.position;

       while (time < duration)
       {
            character.transform.position = Vector3.Lerp(startPos, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
       }

       character.transform.position = targetPosition;

    }

    private void NextSentence()
    {
        //swap characters
        notTalking.SetActive(true);
        notTalking2.SetActive(true);

        if (notTalking.transform.position == offScreen1)
        {
            StartCoroutine(SwapCharacter(notTalking2, offScreen2, time));
            StartCoroutine(SwapCharacter(notTalking, onScreen, time));
        }
        else if (notTalking.transform.position == onScreen)
        {
            StartCoroutine(SwapCharacter(notTalking, offScreen1, time));
            StartCoroutine(SwapCharacter(notTalking2, onScreen, time));
        }

        if (index < sentences.Length - 1)
        {
            index++;
            text.text = "";

            //start typing
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";

            //Next Scene  - Main Scene
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void skipDialogue()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("clicked the button");
    }
}
