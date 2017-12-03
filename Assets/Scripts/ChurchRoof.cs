using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchRoof : MonoBehaviour {

    [SerializeField]
    private GameObject roof;

    private void Start()
    {
        roof.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered church");
        if(collision.transform.CompareTag("Player"))
            roof.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited church");
        if (collision.transform.CompareTag("Player"))
            roof.SetActive(true);
    }
}
