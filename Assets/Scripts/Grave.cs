using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public Transform m_spawnObject;
    public bool isTreasure = false;
    public enum TombstoneType { ROUNDED_TOP_EDGE, ROUNDED, SMALL_CROSS, CIRCULAR_CROSS, LARGE_CROSS }
    public TombstoneType type;
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
		Instantiate(m_spawnObject, transform.position, Quaternion.identity);
		Instantiate(m_spawnObject, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
