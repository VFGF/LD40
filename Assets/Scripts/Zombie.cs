using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Transform m_target;
	float m_speed;
	private SpriteRenderer m_sr;
	public LayerMask m_collideMask;
	Vector2 m_targetPos;

	void Start()
	{
		m_target = GameObject.Find("Player").transform;
		m_sr = GetComponent<SpriteRenderer>();
		m_speed = Random.Range(0.5f, 1f);
    }

    void Update()
    {
		Debug.DrawLine(transform.position, m_targetPos);

		float step = m_speed * Time.deltaTime;
		Vector2 newPos = 
			Vector2.MoveTowards(transform.position, m_targetPos, step);
		transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

		HandleSprite();
	}

	void HandleSprite()
	{
		m_sr.flipX = m_target.position.x > transform.position.x ? 
			true : false;
	}

	void FixedUpdate()
	{
		Vector2 dir = m_target.position - transform.position;

		float flip = 1.0f;
		while(true)
		{
			flip *= -2.0f;

			RaycastHit2D hit = Physics2D.Raycast(
			transform.position,
			dir.normalized,
			dir.magnitude,
			m_collideMask);

			if (!hit.collider)
			{
				m_targetPos = (Vector2)transform.position + dir;
				break;
			}
			else
			{
				dir = Vector2Ex.Rotate(dir, 20.0f * flip);
			}
			if (Mathf.Abs(flip) > 5.0f)
			{
				m_targetPos = transform.position;
			}
		}
	}
}
