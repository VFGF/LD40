using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] debris;

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
            int index = Random.Range(0, debris.Length);
            float spawnX = Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Instantiate(debris[index], new Vector3(spawnX, spawnY), Quaternion.identity);
        }
    }
}
