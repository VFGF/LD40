using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomizedMovement))]
public class Brain : MonoBehaviour {

    private RandomizedMovement m_rm;

    void Start()
    {
        m_rm = GetComponent<RandomizedMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            Debug.Log("Collided");
            m_rm.direction = -m_rm.direction;
            m_rm.FlipSprite();
        }
        else
        {
            Debug.Log("Caught");
            Destroy(gameObject);
        }
    }
}
