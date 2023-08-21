using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    GameControl gameControl = default;

    void Start()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        gameControl = Camera.main.GetComponent<GameControl>();

        float direct = Random.Range(0f, 1.0f);
        if (direct < 0.5)
        {
            //left move
            rb2D.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2D.AddTorque(direct * 3.0f);
        }
        else
        {
            //right move
            rb2D.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2D.AddTorque(-direct * 3.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameControl.AsteroidHasDestroyed(gameObject);
            DestroyAsteroid();
        }
    }

    public void DestroyAsteroid()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
