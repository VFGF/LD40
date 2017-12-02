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
	bool m_paused = false;

	float timer = 0.0f;

	void Start ()
	{

	}
	
	void Update ()
	{
	}

	public void OnGUI()
	{

		if (m_paused)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				m_paused = false;
				int length = m_currentText.Length;
				m_currentText = "" + m_printMessage[length - 1];
				m_printMessage = m_printMessage.Remove(0, length - 1);
			}
			else
				return;
		}
		if (m_donePrinting)
			return;

		timer += Time.fixedDeltaTime;
		if (timer >= 0.01f)
		{
			timer -= 0.01f;

			if (m_currentText.Length == m_printMessage.Length)
				m_donePrinting = true;

			if (!m_donePrinting)
			{
				if (m_text.isTextOverflowing)
				{
					m_currentText = m_currentText.Remove(m_currentText.Length - 1);
					print(m_printMessage);
					m_paused = true;
				}

				if(!m_paused)
					m_currentText += m_printMessage[m_currentText.Length];
			}
		}

		m_text.SetText(m_currentText);
	}

	public void PrintText(string message)
	{
		m_printMessage = message;
		m_currentText = "";
		m_donePrinting = false;
	}

	public void ResetText()
	{
		m_printMessage = "";
		m_currentText = "";
		m_text.text = "";
	}
}
