﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_spawnObjects;
    public bool isTreasure = false;
    [SerializeField]
    public string type;
    public int zone = -1;

    private void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
		if (!isTreasure || zone != -1)
			return;
		ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
        if (bound)
        {
			int.TryParse("" + bound.gameObject.transform.name[4], out zone);
			print("The treasure has appeared in zone " + zone);
		}
	}

	void Dig()
	{
        if (!isTreasure)
        {
            int index = Random.Range(0, 3);
            Instantiate(m_spawnObjects[index], transform.position, Quaternion.identity);
            index = Random.Range(0, 3);
            Instantiate(m_spawnObjects[index], transform.position, Quaternion.identity);
        }
        else
        {
            GameManager.instance.Win();
        }
		Destroy(gameObject);
	}
}
