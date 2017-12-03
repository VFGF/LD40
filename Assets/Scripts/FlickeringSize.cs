using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringSize : MonoBehaviour {

    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    private SpriteRenderer m_sr;
    [SerializeField]
    private int timer;
    private int startTimer;

	// Use this for initialization
	void Start () {
        m_sr = GetComponent<SpriteRenderer>();
        startTimer = timer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer == 0)
        {
            float strength = Random.Range(min, max);
            m_sr.color = new Color(1f, 1f, 1f, Mathf.Clamp01(strength) - 0.1f);
            transform.localScale = new Vector2(strength, strength);
            timer = startTimer;
        }
        else
        {
            timer--;
        }
	}
}
