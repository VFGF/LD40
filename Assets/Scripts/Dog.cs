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

    private Vector3 startPos;

    private float jumpY;
    private Vector3 rayStart;

	void Start ()
	{
		m_animator = GetComponent<Animator>();
		m_sr = GetComponent<SpriteRenderer>();

        startPos = transform.position;
        jumpY = startPos.y + 0.2f;
        rayStart = new Vector3(transform.position.x, startPos.y, transform.position.z);
    }
	
	void Update ()
	{
		transform.position += (Vector3)m_direction.normalized * m_speed * Time.deltaTime;

		m_sr.flipX = m_direction.x > 0.0f;
	}

	void FixedUpdate()
	{
		RaycastHit2D hit = Physics2D.CircleCast(rayStart, 0.2f, Vector2.up, 0.0f, m_mask);
		Debug.DrawRay(transform.position, Vector2.up * 0.1f, Color.blue);
        if(hit.collider)
        {
            m_animator.SetBool("Jumping", true);
            transform.position = new Vector3(transform.position.x, jumpY, transform.position.z);
        }
        else
        {
            Debug.Log("Jumping is false");
            m_animator.SetBool("Jumping", false);
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.CompareTag("Player")) {
            GameManager.instance.LoseHealth();
        }
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
