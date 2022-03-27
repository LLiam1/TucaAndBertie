using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanging : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onVN()
    {
        SceneManager.LoadScene("dialogueAnimation");
    }

    public void onBuild()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
