using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    CountdownTimer countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.TotalTime = 1;
        countdownTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTimer.Over)
        {
            Destroy(gameObject);
        }
    }
}
