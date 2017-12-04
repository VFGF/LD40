using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Transform m_target;
	float m_speed;
	private SpriteRenderer m_sr;
	public LayerMask m_collideMask;
	Vector2 m_targetPos;
	float m_knockbackTimer = 0.0f;
	Vector2 m_knockbackDirection;
    [SerializeField]
    private GameObject brainPrefab;
    [SerializeField]
    private float spawnChance = 10f;

    [SerializeField]
    private GameObject graveSpawnPointPrefab;

	public float m_health = 5.0f;
    //[SerializeField]
    //private float lifeTime = 30f;

	void Start()
	{
		m_target = GameObject.Find("Player").transform;
		m_sr = GetComponent<SpriteRenderer>();
		m_speed = Random.Range(0.5f, 1f);
        //StartCoroutine(lifeTimeEnd());
    }

    /* Killing the zombie after a lifetime
    IEnumerator lifeTimeEnd()
    {
        yield return new WaitForSeconds(lifeTime);
        Die();
    }
    */

    void Update()
    {
		if(m_knockbackTimer > 0.0f)
		{
			m_knockbackTimer -= Time.deltaTime;
			transform.position += (Vector3)m_knockbackDirection.normalized * Time.deltaTime * 5.0f;
		}
		else
		{
			Vector2 dir = (m_target.position - transform.position).normalized * m_speed;
			transform.position += (Vector3)dir * Time.deltaTime;
		}

		HandleSprite();
	}

	void HandleSprite()
	{
		m_sr.flipX = m_target.position.x > transform.position.x ? 
			true : false;
	}

	void FixedUpdate()
	{
		m_targetPos = m_target.position;
	}

	void Damage(float amount)
	{
		m_health -= amount;
		if(m_health <= 0.0f)
		{
            Die();
        }
	}

    void Die()
    {
        float rng = Random.Range(0f, 100f);
        if (rng <= spawnChance)
        {
            Vector2 spawnPosition = transform.position + new Vector3(0f, 0.5f);
            Instantiate(brainPrefab, spawnPosition, Quaternion.identity);

        }

        Instantiate(graveSpawnPointPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

	void Knockback(Vector2 direction)
	{
		m_knockbackDirection = direction;
		m_knockbackTimer = 0.2f;
	}
}
