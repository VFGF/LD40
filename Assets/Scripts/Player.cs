using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public BoxCollider2D m_currentZone = null;
	public float m_zoneSkipDistance = 2.0f;
	CameraController m_camera;

	void Start () {
		m_camera = Camera.main.transform.GetComponent<CameraController>();
	}
	
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
		if (bound && bound.m_collider != m_currentZone)
		{
			m_camera.m_currentBounds = bound.m_collider;
			m_currentZone = bound.m_collider;
			ZoneBound.CurrentZone = bound;
			GameManager.instance.NewZone();
		}
	}
}
