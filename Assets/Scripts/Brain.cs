using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomizedMovement))]
public class Brain : MonoBehaviour {

    private RandomizedMovement m_rm;
	bool m_pickedUp = false;

    void Start()
    {
        m_rm = GetComponent<RandomizedMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            m_rm.direction = -m_rm.direction;
            m_rm.FlipSprite();
        }
        else
        {
			if(!m_pickedUp)
			{
				m_pickedUp = true;
				GameManager.instance.GainHealth();
				Destroy(gameObject);
			}
        }
    }
}
