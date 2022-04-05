using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happinessMeter : MonoBehaviour
{
    float happiness = 1.0f;
    const float HAPPINESS_GAIN = .20f;

    //timer stuff increase/decrease happiness over time
    float nextInc;
    float howLongUntilHapp = 10.0f;
    float howLongUntilNotHapp = 25.0f;

    public bool completedGoal;

    // Start is called before the first frame update
    void Start()
    {
        completedGoal = true;
        Debug.Log(happiness);
    }

    // Update is called once per frame
    void Update()
    {
        if (completedGoal)
        {
            IncreaseHappiness();
        }
        else
        {
            DecreaseHappiness();
        }
    }

    private void IncreaseHappiness()
    {
        if (Time.time >= nextInc)
        {
            happiness += (happiness * HAPPINESS_GAIN);
            Debug.Log(happiness);

            nextInc = Time.time + howLongUntilHapp;
        }
    }

    private void DecreaseHappiness()
    {
        if (Time.time >= nextInc)
        {
            happiness -= (happiness * HAPPINESS_GAIN);
            Debug.Log(happiness);

            nextInc = Time.time + howLongUntilNotHapp;
        }
    }
}
