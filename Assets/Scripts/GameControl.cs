using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    UIControl uicontrol;

    [SerializeField]
    GameObject spaceShipPrefab;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();

    GameObject spaceShip;

    List<GameObject> asteroidList = new List<GameObject>();

    [SerializeField]
    int difficulty = 1;

    [SerializeField]
    int multiper = 5;

    void Start()
    {

    }

    public void StartGame()
    {
        spaceShip = Instantiate(spaceShipPrefab);
        spaceShip.transform.position = new Vector3(0, ScreenCalculator.Bottom + 1.2f);
        ProductionOfAsteroid(5);
    }



    void ProductionOfAsteroid(int number)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < number; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(ScreenCalculator.Left, ScreenCalculator.Right);
            position.y = ScreenCalculator.Top - 1;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);
            asteroidList.Add(asteroid);
        }
    }

    public void AsteroidHasDestroyed(GameObject asteroid)
    {
        uicontrol.AsteroidHasDestroyed(asteroid);
        asteroidList.Remove(asteroid);
        if (asteroidList.Count <= difficulty)
        {
            difficulty++;
            ProductionOfAsteroid(difficulty * multiper);
        }
    }

    public void FinishGame()
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().DestroyAsteroid();
        }
        asteroidList.Clear();
        difficulty = 1;
    }
}
