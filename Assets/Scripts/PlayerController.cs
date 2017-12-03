using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	// Movement
	public float m_movementSpeed = 3.0f;
	Vector3 m_movementDir = Vector3.zero;
	Rigidbody2D m_rb;

    // Animation
    Animator m_anim;
    public int m_direction = 0;

	// Attacking
	public LayerMask m_attackMask;


	void Start ()
	{
		m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		HandleInput();
	}

	void HandleInput()
	{
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        m_movementDir = new Vector2(
			horizontal, vertical);
		m_movementDir.Normalize();

		if (horizontal > Mathf.Epsilon)
		{
			m_direction = 1;        // Right
			transform.localScale = new Vector2(-1f, 1f);
		}
		else if (horizontal < -Mathf.Epsilon)
		{
			m_direction = 2;        // Left
			transform.localScale = new Vector2(1f, 1f);
		}
		else if (vertical > Mathf.Epsilon)
			m_direction = 3;        // Up
		else if (vertical < -Mathf.Epsilon)
			m_direction = 4;        // Down

        if(m_movementDir != Vector3.zero)
        {
            m_anim.SetBool("Walking", true);
        }
        else
        {
            m_anim.SetBool("Walking", false);
        }

        m_anim.SetInteger("Direction", m_direction);

        if(Input.GetButtonDown("Fire1"))
        {
            m_anim.SetBool("Attack", true);
			SendMessage("Attack");
        }
        else
        {
            m_anim.SetBool("Attack", false);
        }

        if (Input.GetAxisRaw("Fire2") > 0f)
        {
            m_anim.SetBool("Digging", true);
        }
        else
        {
            m_anim.SetBool("Digging", false);
        }
    }

	void FixedUpdate()
	{
		m_rb.velocity = m_movementDir * m_movementSpeed;
	}

	void Attack()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, m_movementDir, 2.0f, m_attackMask);

		float damage = 1.0f;
		if(hit.collider)
		{
			print("hit");
			hit.collider.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
		}
	}
}
