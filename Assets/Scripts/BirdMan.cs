using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMan : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private float chance;
    [SerializeField]
    private int index;
    private int startIndex;

    [SerializeField]
    private Gate gateScript;

    private SpriteRenderer m_sr;

	// Use this for initialization
	void Start () {
        m_sr = GetComponent<SpriteRenderer>();
        startIndex = index;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float rng = Random.Range(0f, 100f);
        if(rng < chance)
        {
            if (index < sprites.Length - 1)
                index++;
            else
                index = startIndex;
            m_sr.sprite = sprites[index];
        }
	}

    public void OpenGate()
    {
        gateScript.OpenGate();
    }
}
