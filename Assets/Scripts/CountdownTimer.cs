using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    float totalTime;
    float passingTime;
    bool isWorking = false;
    bool hasStarted = false;

    /// <summary>
    /// Set the total time of countdown timer.
    /// </summary>
    public float TotalTime
    {
        set
        {
            if (!isWorking)
            {
                totalTime = value;
            }
        }
    }

    /// <summary>
    /// Say counting time is over or not.
    /// </summary>

    public bool Over
    {
        get
        {
            return hasStarted && !isWorking;
        }
    }

    /// <summary>
    /// Start counting.
    /// </summary>
    public void Start()
    {
        if (totalTime > 0)
        {
            isWorking = true;
            hasStarted = true;
            passingTime = 0;
        }
    }

    void Update()
    {
        if (isWorking)
        {
            passingTime += Time.deltaTime;
            if (passingTime >= totalTime)
            {
                isWorking = false;
            }
        }
    }
}
