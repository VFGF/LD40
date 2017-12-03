using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
	public Vector2 m_direction;
	public float m_speed;
	Animator m_animator;
	public LayerMask m_mask;
	SpriteRenderer m_sr;
	public ZoneBound m_zone;

	void Start ()
	{
		m_animator = GetComponent<Animator>();
		m_sr = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		transform.position += (Vector3)m_direction.normalized * m_speed * Time.deltaTime;

		m_sr.flipX = m_direction.x > 0.0f;
	}

	void FixedUpdate()
	{
		RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.2f, Vector2.up, 0.0f, m_mask);
		Debug.DrawRay(transform.position, Vector2.up * 0.1f, Color.blue);
		m_animator.SetBool("Jumping", hit.collider ? true : false);
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
		if (bound)
		{
			print("what");
			if(bound == m_zone)
			{
				Destroy(gameObject);
			}
		}
	}
}
