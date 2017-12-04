using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GrimReaperManager))]
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int health = 3;
    [SerializeField]
    private int maxHealth = 5;
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private List<GameObject> healthIconList = new List<GameObject>();
    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private GameObject graves;
    [SerializeField]
    private List<GameObject> graveList;
    [SerializeField]
    private GameObject treasureGrave;

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
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart ()
    {
        yield return new WaitForSeconds(0.1f);

        if (graves == null)
            GameObject.Find("Graves");

        if (graveList.Count == 0)
        {
            foreach (Transform child in graves.transform)
            {
                graveList.Add(child.gameObject);
            }
        }

        int index = Random.Range(0, graveList.Count - 1);
        graveList[index].GetComponent<Grave>().isTreasure = true;
        treasureGrave = graveList[index];
    }

    public void NewZone()
    {
        grm.ResetTimer();
    }

    public void GameOver()
    {
        if(!gameOver)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }

    public void LoseHealth()
    {
        LoseHealth(1);
    }

    public void LoseHealth(int damage)
    {
        if (!gameOver)
        {
            health -= damage;
            RenderHealth();
            if (health <= 0)
                GameOver();
        }
    }

    public void GainHealth()
    {
        if (health < maxHealth)
        {
            health++;
            RenderHealth();
        }
    }

    public void RenderHealth()
    {
        if (health >= 0)
        {
            foreach (GameObject healthIconObject in healthIconList)
            {
                Destroy(healthIconObject);
            }
            healthIconList.Clear();

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

    public void SpawnGrim()
    {
        grm.SpawnGrim();
    }
}
