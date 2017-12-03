using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedObjectSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] gameObjects;

    [SerializeField]
    private int amount;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, gameObjects.Length);
            float spawnX = Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Instantiate(gameObjects[index], new Vector3(spawnX, spawnY), Quaternion.identity);
        }
    }
}
