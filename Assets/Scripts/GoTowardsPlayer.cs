using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsPlayer : MonoBehaviour {

    private GameObject target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool killPlayer;
    [SerializeField]
    private bool hurtPlayer;
    [SerializeField]
    private int damage;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (killPlayer)
                GameManager.instance.GameOver();
            else if (hurtPlayer)
            {
                GameManager.instance.LoseHealth(damage);
            }
        }
    }
}
