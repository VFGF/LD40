using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GrimReaperManager))]
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int health = 3;
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private List<GameObject> healthIconList = new List<GameObject>();
    [SerializeField]
    private GameObject UI;

    public bool gameOver = false;

    private GrimReaperManager grm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        grm = GetComponent<GrimReaperManager>();
        RenderHealth();
    }

    public void NewZone()
    {
        grm.ResetTimer();
    }

    public void LoseHealth()
    {
        health--;
        RenderHealth();
    }

    public void GainHealth()
    {
        health++;
        RenderHealth();
    }

    public void RenderHealth()
    {
        for (int i = 0; i < health; i++)
        {
            GameObject healthIcon = Instantiate(healthPrefab, UI.transform.position, Quaternion.identity, UI.transform);

            RectTransform m_rectTransform;
            m_rectTransform = healthIcon.GetComponent<RectTransform>();

            m_rectTransform.anchorMin = new Vector2(0f, 1f);
            m_rectTransform.anchorMax = new Vector2(0f, 1f);
            m_rectTransform.pivot = new Vector2(0f, 1f);

            m_rectTransform.anchoredPosition = new Vector2(i * 100f + 10f, -10f);
            healthIconList.Add(healthIcon);
        }
    }
}
