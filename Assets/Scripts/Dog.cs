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
    private bool hasHurtPlayer = false;

	void Start ()
	{
		m_animator = GetComponent<Animator>();
		m_sr = GetComponent<SpriteRenderer>();

        startPos = transform.position;
        jumpY = startPos.y + 0.2f;
    }
	
	void Update ()
	{
		transform.position += (Vector3)m_direction.normalized * m_speed * Time.deltaTime;
		m_sr.flipX = m_direction.x > 0.0f;
	}

	void FixedUpdate()
	{
		rayStart = new Vector3(transform.position.x, startPos.y, transform.position.z);
		RaycastHit2D hit = Physics2D.CircleCast(rayStart, 0.2f, Vector2.up, 0.0f, m_mask);
		if (!hit.collider)
			return;
        if(hit.collider.transform.CompareTag("Bush"))
        {
            m_animator.SetBool("Jumping", true);
            transform.position = new Vector3(transform.position.x, jumpY, transform.position.z);
        }
        else
        {
            m_animator.SetBool("Jumping", false);
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
		
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.transform.CompareTag("Player")) {
            if (!hasHurtPlayer)
            {
                GameManager.instance.LoseHealth();
                hasHurtPlayer = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
	{
		ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
		if (bound)
		{
			if(bound == m_zone)
			{
				Destroy(gameObject);
			}
		}
	}
}
