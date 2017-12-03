using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoneBound : MonoBehaviour
{
	public BoxCollider2D m_collider;

	// Dogs
	public bool m_spawnDogs = false;
	public float m_dogRate = 0.2f;
	float m_dogTimer = 0.0f;
	public Dog m_dogPrefab;

	static ZoneBound m_currentZone = null;
	public static ZoneBound CurrentZone
	{
		get { return m_currentZone; }
		set { m_currentZone = value; }
	}

	void Start()
	{
		m_collider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		if(m_currentZone == this)
		{
			HandleDogs();
		}
	}

	void HandleDogs()
	{
		if (!m_spawnDogs)
			return;

		m_dogTimer += Time.deltaTime;
		if(m_dogTimer >= m_dogRate)
		{
			m_dogTimer -= m_dogRate;

			float side = Random.value < 0.5f ? -1.0f : 1.0f;
			
			Vector2 randomPos = new Vector2(side * m_collider.size.x * transform.localScale.x * 0.5f, (Random.value * 2.0f - 1.0f) * m_collider.size.y * transform.localScale.y * 0.5f);
			Dog dog = Instantiate(m_dogPrefab, randomPos + (Vector2)transform.position, Quaternion.identity).GetComponent<Dog>();
			dog.m_direction = Vector2.right * -side;
			dog.m_speed = 2.0f;
			dog.m_zone = this;
		}
	}
}
