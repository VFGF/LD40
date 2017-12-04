using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public Transform m_spawnObject;
    public bool isTreasure = false;
    public enum TombstoneType { ROUNDED_TOP_EDGE, ROUNDED, SMALL_CROSS, CIRCULAR_CROSS, LARGE_CROSS }
    public TombstoneType type;
    public int zone;

    private void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        ZoneBound bound = coll.transform.GetComponent<ZoneBound>();
        if (bound)
        {
            switch (bound.gameObject.transform.name)
            {
                case "zone0":
                    zone = 0;
                    break;
                case "zone1":
                    zone = 1;
                    break;
                case "zone2":
                    zone = 2;
                    break;
                case "zone3":
                    zone = 3;
                    break;
                case "zone4":
                    zone = 4;
                    break;
                case "zone5":
                    zone = 5;
                    break;
                case "zone6":
                    zone = 6;
                    break;
                case "zone7":
                    zone = 7;
                    break;
                case "zone8":
                    zone = 8;
                    break;
                case "zone9":
                    zone = 9;
                    break;
            }
        }
    }

    void Dig()
	{
		Instantiate(m_spawnObject, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
