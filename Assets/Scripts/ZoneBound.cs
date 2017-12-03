using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoneBound : MonoBehaviour
{
	public BoxCollider2D m_collider;
	void Start()
	{
		m_collider = GetComponent<BoxCollider2D>();
	}
}
