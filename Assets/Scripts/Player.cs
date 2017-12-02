using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public BoxCollider2D m_currentZone;
	public float m_zoneSkipDistance = 2.0f;
	CameraController m_camera;

	void Start () {
		m_camera = Camera.main.transform.GetComponent<CameraController>();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Bounds bound = coll.transform.GetComponent<Bounds>();
		if (bound)
		{
			BoxCollider2D otherZone = null;
			for(int i = 0; i < 2; i++)
			{
				if(bound.m_camBounds[i] != m_currentZone)
				{
					otherZone = bound.m_camBounds[i];
					break;
				}
			}


			m_camera.m_currentBounds = otherZone;

			Vector2 skipDir = 
			transform.position += 
				(otherZone.transform.position - m_currentZone.transform.position).normalized 
				* m_zoneSkipDistance;

			m_currentZone = otherZone;
		}
	}
}
