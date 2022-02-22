using System.Collections;
using TMPro;
using UnityEngine;


public class animationDialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] sentences;
    public GameObject talk;
    public GameObject notTalking;
    private int index;

    IEnumerator Type() 
    {
        foreach (char letters in sentences[index].ToCharArray()) 
        {
            talk.SetActive(true);
            notTalking.SetActive(false);
            text.text += letters;
            yield return new WaitForSeconds(.02f);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text == sentences[index])
        {
            notTalking.SetActive(true);
            talk.SetActive(false);

            if (Input.GetMouseButton(0))
            {
                NextSentence();
            }
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
