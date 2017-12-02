using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	// Movement
	public float m_movementSpeed = 3.0f;
	Vector3 m_movementDir = Vector3.zero;
	Rigidbody2D m_rb;


	void Start ()
	{
		m_rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		HandleInput();
	}

	void HandleInput()
	{
		m_movementDir = new Vector2(
			Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		m_movementDir.Normalize();
	}

	void FixedUpdate()
	{
		m_rb.velocity = m_movementDir * m_movementSpeed;
	}
}
