using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
	float time = 0.0f;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		time += Time.deltaTime;
		if(time >= 3.0f)
		{
			SceneManager.LoadScene("Level");
		}
	}
}
