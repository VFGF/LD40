using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoneBound : MonoBehaviour
{
	BoxCollider2D m_collider;
	public BoxCollider2D[] m_camBounds;

	void OnValidate()
	{
		Array.Resize<BoxCollider2D>(ref m_camBounds, 2);		
	}
}
