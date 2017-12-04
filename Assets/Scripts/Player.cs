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

	void OnTriggerStay2D(Collider2D coll)
	{
		ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
		if (bound)
		{
			m_camera.m_currentBounds = bound.m_collider;
			m_currentZone = bound.m_collider;
			ZoneBound.CurrentZone = bound;
		}
	}
    private void OnTriggerEnter2D(Collider2D coll)
    {
        ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
        if (bound)
        {
            GameManager.instance.NewZone();
        }
    }
}
