using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveSpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject[] graves;

	// Use this for initialization
	void Start () {
        int index = Random.Range(0, graves.Length);
        Instantiate(graves[index], transform.position, Quaternion.identity);
        Destroy(gameObject);
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(0.4f, 0.6f, 1f));
    }
}
