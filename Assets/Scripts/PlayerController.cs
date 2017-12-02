﻿using System.Collections;
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
    public int m_direction;


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

        if(horizontal > Mathf.Epsilon)
        {
            m_direction = 0;        // Right
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (horizontal < -Mathf.Epsilon)
        {
            m_direction = 1;        // Left
            transform.localScale = new Vector2(1f, 1f);
        }

        else if (vertical > Mathf.Epsilon)
        {
            m_direction = 2;        // Up
        }
        else if (vertical < -Mathf.Epsilon)
        {
            m_direction = 3;        // Down
        }

        if(m_movementDir != Vector3.zero)
        {
            m_anim.SetBool("Walking", true);
        }
        else
        {
            m_anim.SetBool("Walking", false);
        }

        m_anim.SetInteger("Direction", m_direction);

        if(Input.GetAxisRaw("Fire1") > 0f)
        {
            m_anim.SetBool("Attack", true);
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
}
