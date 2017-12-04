﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Npc : MonoBehaviour
{
	public string m_name;
	public Dialogue m_dialogue;
	[TextArea]
	public string m_text;

    private BirdMan birdManScript;

    private void Start()
    {
        if (GetComponent<BirdMan>() != null)
            birdManScript = GetComponent<BirdMan>();
    }

    private void Update()
    {
        if(m_dialogue.m_isFinished && birdManScript != null)
        {
            birdManScript.OpenGate();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
	{
        if (coll.transform.CompareTag("Player"))
        {
			m_dialogue.gameObject.SetActive(true);
			m_dialogue.PrintText(m_text);
        }
	}

	void OnTriggerExit2D(Collider2D coll)
	{
        if (coll.transform.CompareTag("Player"))
        {
			m_dialogue.ResetText();
			m_dialogue.gameObject.SetActive(false);
        }
	}
}
