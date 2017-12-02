using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour {
	public bool m_dynamic = false;

    [SerializeField]
    private float offset;

	void Start()
	{
		Vector3 position = transform.position;
		position.z = position.y * 0.1f;
		transform.position = position;
	}

	void Update () {
		if(m_dynamic)
		{
			Vector3 position = transform.position;
			position.z = position.y * 0.1f;
			transform.position = position;
		}
	}
}
