using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControl : MonoBehaviour
{
    GameControl gameControl;

    [SerializeField]
    GameObject bulletPrefab = default;

    [SerializeField]
    GameObject explosionPrefab = default;

    const float movingForce = 5;

    void Start()
    {
        gameControl = Camera.main.GetComponent<GameControl>();
    }

    /// <summary>
    /// Controlling space ship with keyboard.
    /// </summary>
    void Update()
    {

        Vector3 position = transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            position.x += horizontalInput * movingForce * Time.deltaTime;
        }

        if (verticalInput != 0)
        {
            position.y += verticalInput * movingForce * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 bulletPosition = gameObject.transform.position;
            bulletPosition.y += 1;
            Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            gameControl.FinishGame();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
