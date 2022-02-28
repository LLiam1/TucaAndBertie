using System.Collections;
using TMPro;
using UnityEngine;


public class animationDialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI whosTalking;
    public string[] sentences;
    public GameObject talk;
    public GameObject notTalking;
    public GameObject talk2;
    public GameObject notTalking2;
    private int index;

    private void Awake()
    {
        text.text = "";
    }

    void Start()
    {
        StartCoroutine(Type());
    }


    void Update()
    {
        if (text.text == sentences[index])
        {
            if (index % 2 == 0)
            {
                talk.SetActive(false);
                notTalking.SetActive(true);
            }
            else
            {
                talk2.SetActive(false);
                notTalking2.SetActive(true);
            }

            if (Input.GetMouseButton(0))
            {
                NextSentence();
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letters in sentences[index].ToCharArray())
        {
            if (index % 2 == 0)
            {
                whosTalking.text = "character 1";

                talk.SetActive(true);
                notTalking.SetActive(false);

                talk2.SetActive(false);
                notTalking2.SetActive(false);
            }
            else
            {
                whosTalking.text = "character 2";

                talk2.SetActive(true);
                notTalking2.SetActive(false);

                talk.SetActive(false);
                notTalking.SetActive(false);
            }
            text.text += letters;
            yield return new WaitForSeconds(.02f);

        }
    }

    private void NextSentence() 
    {
        if (index < sentences.Length - 1)
        {
            index++;
            text.text = "";
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";
        }
    }
}
