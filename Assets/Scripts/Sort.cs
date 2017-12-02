using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour {	
	void Update () {
		Vector3 position = transform.position;
		position.z = position.y * 0.01f;
		transform.position = position;
	}
}
