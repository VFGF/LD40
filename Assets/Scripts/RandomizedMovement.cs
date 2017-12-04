using System.Collections;
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
    public Vector2 direction = Vector2.zero;

    private Rigidbody2D m_rb;
    private SpriteRenderer m_sr;

    [SerializeField]
    private bool isBrain;

    private GameObject player;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        Randomize();
    }

    private void Update()
    {
        if(duration >= 0)
            duration -= Time.deltaTime;
        else
            Randomize();
    }

    private void Randomize()
    {
        duration = Random.Range(durationMin, durationMax);

        direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f));
        direction.Normalize();

        FlipSprite();
    }

    private void FixedUpdate()
    {
        m_rb.velocity = direction * speed;
    }

    public void FlipSprite()
    {
        if (direction.x > Mathf.Epsilon)
        {
            m_sr.flipX = true;
        }
        if (direction.x < Mathf.Epsilon)
        {
            m_sr.flipX = false;
        }
    }
}
