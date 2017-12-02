using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour {

    [SerializeField]
    private float maxRotation = 360f;
    [SerializeField]
    private float minRotation = 0f;

    [SerializeField]
    private float maxSize = 1.2f;
    [SerializeField]
    private float minSize = 0.8f;

    void OnValidate()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, Random.Range(minRotation, maxRotation));
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(randomSize, randomSize);
    }
}
