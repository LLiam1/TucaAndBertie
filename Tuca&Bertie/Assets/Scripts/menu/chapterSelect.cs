using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chapterSelect : MonoBehaviour
{
    public string character;
    //public happinessMeter happiness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if (happiness.character == character && happiness.happiness >= 50.0f)
       //{
       //     gameObject.SetActive(true);
       //}
    }

    public void Click()
    {
        SceneManager.LoadScene(character);
    }
}
