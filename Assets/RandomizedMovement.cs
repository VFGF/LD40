﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedMovement : MonoBehaviour {

    [SerializeField]
    private float durationMin;
    [SerializeField]
    private float durationMax;
    [SerializeField]
    private float speed;

    private float duration;
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D m_rb;
    private SpriteRenderer m_sr;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sr = GetComponent<SpriteRenderer>();
        Randomize();
    }

    private void Update()
    {
        if(duration >= 0)
            duration -= Time.deltaTime;
        else
            Randomize();

        //transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Randomize()
    {
        duration = Random.Range(durationMin, durationMax);
        direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f));
        direction.Normalize();
        Debug.Log(direction.x.ToString() + " " + direction.y.ToString());

        if(direction.x > Mathf.Epsilon)
        {
            m_sr.flipX = true;
        }
        if(direction.x < Mathf.Epsilon)
        {
            m_sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        m_rb.velocity = direction * speed;
    }
}
