using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CountdownTimer countdownTimer;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.TotalTime = 3;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {

            Destroy(gameObject);
        }
    }
}
