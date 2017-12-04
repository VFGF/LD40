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
	Vector2 m_movementDir = Vector3.zero;
	Rigidbody2D m_rb;

	// Attacking
	Vector2 m_facingDir = Vector2.left;
	public float m_attackDistance = 0.7f;

	// Animation
	Animator m_anim;
    public int m_direction = 0;

	// Attacking
	public LayerMask m_attackMask;

	// Digging
	public LayerMask m_digMask;

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

        if(m_movementDir != Vector2.zero)
        {
            m_anim.SetBool("Walking", true);
			m_facingDir = m_movementDir.normalized;
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

        if (Input.GetButtonDown("Fire2"))
        {
            m_anim.SetBool("Digging", true);
			SendMessage("Dig");
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
		RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up * 0.3f, m_facingDir, m_attackDistance, m_attackMask);
		Debug.DrawRay((Vector2)transform.position + Vector2.up * 0.3f, m_facingDir * m_attackDistance);

		float damage = 1.0f;
		if(hit.collider)
		{
			hit.collider.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
			hit.collider.gameObject.SendMessage("Knockback", m_facingDir, SendMessageOptions.DontRequireReceiver);
		}
	}

	void Dig()
	{
		Collider2D result = Physics2D.OverlapCircle(transform.position, 1.0f, m_digMask);
		if(result)
		{
			result.gameObject.SendMessage("Dig");
		}
	}
}
