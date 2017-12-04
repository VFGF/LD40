using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrimReaperManager : MonoBehaviour
{
    [SerializeField]
    private float time;
    private float startTime;

    [SerializeField]
    private GameObject grimPrefab;
    private GameObject grimReaper;
    private bool grimSpawned = false;
    [SerializeField]
    private bool timeRunningOut = false;
    [SerializeField]
    private GameObject timeRunningOutPanel;

    [SerializeField]
    private Image colorPanel;
    private float fadeAmount = 0f;

	Player m_player;

    private void Start()
    {
		m_player = FindObjectOfType<Player>();
        startTime = time;
        ResetTimer();
    }

    public void ResetTimer()
    {
        colorPanel.color = new Color(0f, 0f, 0f, 0f);
        time = startTime;
        grimSpawned = false;
        timeRunningOut = false;
        fadeAmount = 0f;

        if(timeRunningOutPanel.activeSelf)
            timeRunningOutPanel.SetActive(false);

        if (grimReaper != null)
            Destroy(grimReaper);
    }

    private void Update ()
    {
        if (!grimSpawned)
        {
            time -= Time.deltaTime;

            if (time <= 15f && time > 0f && !timeRunningOut)
            {
                timeRunningOut = true;
                timeRunningOutPanel.SetActive(true);

            }
            else if (time <= 0f)
            {
                SpawnGrim();
                timeRunningOutPanel.SetActive(false);
            }
        }

        if(timeRunningOut)
        {
            FadeColorPanel();
        }
	}

    private void SpawnGrim()
    {
		float randomAngle = Random.value * 360.0f;
		Vector2 spawnPos = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
		spawnPos *= 5.0f;
		spawnPos += (Vector2)Camera.main.transform.position;
        grimReaper = Instantiate(grimPrefab, spawnPos, Quaternion.identity);
        grimSpawned = true;
    }

    private void FadeColorPanel()
    {
        fadeAmount += Time.deltaTime / 15f;
        colorPanel.color = Color.Lerp(new Color(0f,0f,0f,0f), new Color(0f,0f,0f,0.5f), fadeAmount);
    }
}
