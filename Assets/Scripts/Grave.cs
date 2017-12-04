using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
	public Transform m_spawnObject;
    public bool isTreasure = false;

	void Dig()
	{
		Instantiate(m_spawnObject, transform.position, Quaternion.identity);
		Instantiate(m_spawnObject, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
