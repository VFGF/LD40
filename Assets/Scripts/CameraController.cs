using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PostProcessing;


public class CameraController : MonoBehaviour
{
	Transform m_player;
	public BoxCollider2D m_currentBounds;
	Vector2 m_currentBoundOrigin;
	Vector2 m_size = Vector2.zero;

    //private PostProcessingProfile m_ppp;
    //private PostProcessingBehaviour m_ppb;

	void Start ()
	{
		m_player = GameObject.Find("Player").transform;
		m_size.y = GetComponent<Camera>().orthographicSize;
		m_size.x = m_size.y * GetComponent<Camera>().aspect;

        //m_ppb = GetComponent<PostProcessingBehaviour>();
	}
	
	void Update ()
	{
		FollowPlayer();
		HandleBounds();
        //HandlePostProcessing();
	}

	void FollowPlayer()
	{
		transform.position = m_player.transform.position - Vector3.forward * 10.0f;
	}

	void HandleBounds()
	{
		m_currentBoundOrigin = m_currentBounds.transform.position;
		Vector3 position = transform.position;
		float xScale = m_currentBounds.transform.localScale.x;
		float yScale = m_currentBounds.transform.localScale.y;
		float xMax = m_currentBoundOrigin.x + m_currentBounds.size.x * 0.5f * xScale;
		float xMin = m_currentBoundOrigin.x - m_currentBounds.size.x * 0.5f * xScale;
		float yMax = m_currentBoundOrigin.y + m_currentBounds.size.y * 0.5f * yScale;
		float yMin = m_currentBoundOrigin.y - m_currentBounds.size.y * 0.5f * yScale;

		if (position.x + m_size.x > xMax)
			position.x = xMax - m_size.x;
		else if (position.x - m_size.x < xMin)
			position.x = xMin + m_size.x;

		if (position.y + m_size.y > yMax)
			position.y = yMax - m_size.y;
		else if (position.y - m_size.y < yMin)
			position.y = yMin + m_size.y;

		transform.position = position;
	}

    /*
    void HandlePostProcessing()
    {
        if(m_currentBounds.transform.name == "zone0")
        {
            m_ppb.profile = m_ppp;
        }
    }
    */
}
