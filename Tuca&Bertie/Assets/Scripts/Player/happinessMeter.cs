using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class happinessMeter : MonoBehaviour
{
    float happiness = 10.0f;
    const float HAPPINESS_GAIN = .20f;

    const float HAPPINESS_MAX = 20.0f;
    const float HAPPINESSS_MIN = 0.0f;

    //timer stuff increase/decrease happiness over time
    float nextInc;
    float howLongUntilHapp = 10.0f;
    float howLongUntilNotHapp = 25.0f;

    public bool completedGoal;

    //VN connection stuff
    public string character;
    public string whichButton;

    // Start is called before the first frame update
    void Start()
    {
        completedGoal = false;
        Debug.Log(happiness);
    }

    // Update is called once per frame
    void Update()
    {
        if (completedGoal)
        {
            IncreaseHappiness();
        }
    }

    private void IncreaseHappiness()
    {
        if (Time.time >= nextInc)
        {
            happiness += (happiness * HAPPINESS_GAIN);
            if (happiness >= HAPPINESS_MAX)
            {
                happiness = HAPPINESS_MAX;
            }

            Debug.Log(happiness);

            nextInc = Time.time + howLongUntilHapp;
        }
    }

    private void DecreaseHappiness()
    {
        if (Time.time >= nextInc)
        {
            happiness -= (happiness * HAPPINESS_GAIN);
            if(happiness <= HAPPINESSS_MIN)
            {
                happiness = HAPPINESSS_MIN;
            }
            Debug.Log(happiness);

            nextInc = Time.time + howLongUntilNotHapp;
        }
    }
}
