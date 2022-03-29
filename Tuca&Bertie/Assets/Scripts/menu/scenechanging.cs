using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanging : MonoBehaviour
{
    void Start()
    {
        
    }

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
