using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer m_sr;

    private void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, sprites.Length);

        m_sr.sprite = sprites[index];
        //Debug.Log("Index: " + index.ToString());
    }
}
