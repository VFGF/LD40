using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Gate : MonoBehaviour {

    private BoxCollider2D m_coll;
    private Animator m_anim;

	// Use this for initialization
	void Start () {
        m_coll = GetComponent<BoxCollider2D>();
        m_anim = GetComponent<Animator>();
	}

    public void OpenGate()
    {
        m_coll.enabled = false;
        m_anim.SetBool("Open", true);
    }

    public void CloseGate()
    {
        m_coll.enabled = true;
        m_anim.SetBool("Open", false);
    }
}
