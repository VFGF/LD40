using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public GameObject target;
    public float speed;
    private SpriteRenderer m_sr;

    void Start()
    {
        target = GameObject.Find("Player");
        m_sr = GetComponent<SpriteRenderer>();
        speed = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        if (target.transform.position.x > transform.position.x)
        {
            m_sr.flipX = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            m_sr.flipX = false;
        }
    }
}
