using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happinessMeter : MonoBehaviour
{
    public float happiness = 15.0f;
    const float HAPPINESS_GAIN = .20f;
    const float HAPPINESS_MAX = 50.0f;

    //timer stuff increase/decrease happiness over time
    float nextInc;
    float howLongUntilHapp = 10.0f;
    float howLongUntilNotHapp = 25.0f;

    public bool completedGoal;
    public string character;

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
            if(happiness >= HAPPINESS_MAX)
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
            Debug.Log(happiness);

            nextInc = Time.time + howLongUntilNotHapp;
        }
    }
}
