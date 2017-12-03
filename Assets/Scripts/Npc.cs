using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Npc : MonoBehaviour
{
	public string m_name;
	public Dialogue m_dialogue;
	[TextArea]
	public string m_text;

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (coll.transform.CompareTag("Player"))
        {
            m_dialogue.PrintText(m_text);
            m_dialogue.gameObject.SetActive(true);
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
