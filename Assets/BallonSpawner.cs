using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    const int NUM_Ballon = 10;
    public GameObject balloonPrefab; 
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        int xMin = -10 ;
        int xMax = 16;
        int yMin = -2;
        int yMax = 2;

        for (int i = 0; i < NUM_Ballon; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(balloonPrefab, position, Quaternion.identity);
        }
    }
}
