using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
	string m_printMessage;
	string m_currentText;
	public TextMeshProUGUI m_text;
	bool m_donePrinting = true;
    public bool m_isFinished = false;
	bool m_paused = false;
	int m_overflow = 0;
	int m_readCount = 0;
	int m_currentStart = 0;

	float m_timer = 0.0f;

	void Start ()
	{

	}
	
	void Update ()
	{
	}

	public void OnGUI()
	{
		if(m_paused)
		{
			if (Input.GetAxisRaw("Enter") > 0.1f)
			{
				m_paused = false;
				m_currentText = "";
				m_currentStart = m_readCount;
			}
			else
				return;
		}

		if(!m_donePrinting)
		{
			m_timer += Time.fixedDeltaTime;
			if (m_timer >= 0.03f)
			{
				m_timer -= 0.03f;

				m_currentText += m_printMessage[m_readCount++];

				if (m_readCount > m_printMessage.Length - 1)
                {
                    m_donePrinting = true;
                    m_isFinished = true;
                }


				if(m_text.isTextOverflowing)
				{
					//print("uheaedkufaef");
					m_overflow = m_text.firstOverflowCharacterIndex + m_currentStart;
					m_readCount = m_overflow;
					m_currentText = m_printMessage.Substring(m_currentStart, m_readCount - m_currentStart);
					m_paused = true;
				}
			}
		}

		m_text.text = m_currentText;
	}

	public void PrintText(string message)
	{
		m_printMessage = message;
		m_currentText = "";
		m_donePrinting = false;
		m_readCount = 0;
	}

	public void ResetText()
	{
		m_printMessage = "";
		m_currentText = "";
		m_text.text = "";
		m_readCount = 0;
	}
}
