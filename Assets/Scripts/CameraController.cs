using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	Transform m_player;
	public BoxCollider2D m_currentBounds;
	Vector2 m_currentBoundOrigin;
	float m_size;

	void Start ()
	{
		m_player = GameObject.Find("Player").transform;
		m_size = GetComponent<Camera>().orthographicSize;
		m_currentBoundOrigin = m_currentBounds.transform.position;
	}
	
	void Update ()
	{
		FollowPlayer();
		HandleBounds();
	}

	void FollowPlayer()
	{
		transform.position = m_player.transform.position - Vector3.forward * 10.0f;
	}

	void HandleBounds()
	{
		Vector3 position = transform.position;
		float xMax = m_currentBoundOrigin.x + m_currentBounds.size.x * 0.5f;
		float xMin = m_currentBoundOrigin.x - m_currentBounds.size.x * 0.5f;
		float yMax = m_currentBoundOrigin.y + m_currentBounds.size.y * 0.5f;
		float yMin = m_currentBoundOrigin.y - m_currentBounds.size.y * 0.5f;

		if (position.x + m_size > xMax)
			position.x = xMax - m_size;
		else if (position.x - m_size < xMin)
			position.x = xMin + m_size;

		if (position.y + m_size > yMax)
			position.y = yMax - m_size;
		else if (position.y - m_size < yMin)
			position.y = yMin + m_size;

		transform.position = position;
	}
}
