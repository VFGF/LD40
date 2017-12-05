using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private Npc snowman;
    private bool snowmanClueGiven = false;

    [SerializeField]
    private Npc benjamin;
    private bool benjaminClueGiven = false;

    public bool gameOver = false;

    private GrimReaperManager grm;

	public bool m_inDialogue = false;

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

	void Update()
	{
		if(m_inDialogue)
		{
			grm.ResetTimer();
		}
	}

    public void GetBenjaminClue()
    {
        if (!benjaminClueGiven)
        {
            string zoneClue = "";
            int graveZone = treasureGrave.GetComponent<Grave>().zone;
            Debug.Log("Gravezone: " + graveZone);

            switch (graveZone)
            {
                case 0:
                    zoneClue = "where the crow keeps watch. Only a few tombstones there, by the fence.";
                    break;
                case 1:
                    zoneClue = "in the maze, that shouldn't even be possible...";
                    break;
                case 2:
                    zoneClue = "where my gallows point. Not too far from here.";
                    break;
                case 3:
                    zoneClue = "very close. The excitement, it gives me chills down my spine!";
                    break;
                case 4:
                    zoneClue = "in the evergreen forest. A very empty part of the graveyard unfortunately.";
                    break;
                case 5:
                    zoneClue = "close to the house of God.";
                    break;
                case 6:
                    zoneClue = "behind the church.";
                    break;
                case 7:
                    zoneClue = "where two really cool guys are having a friendly debate over which economic system is good and which one is an evil virus of satan.";
                    break;
                case 8:
                    zoneClue = "by the first road you traveled in this graveyard.";
                    break;
                case 9:
                    zoneClue = "in the most populated part of the graveyard. Many of my best friends live there in fact. Just start digging, there's a lot of spots.";
                    break;
            }
            benjamin.m_text = benjamin.m_text + zoneClue + " Good luck finding it!";

            benjaminClueGiven = true;
        }
    }

    public void GetSnowmanClue()
    {
        if(!snowmanClueGiven)
        {
            string shapeClue = "";
            shapeClue = treasureGrave.GetComponent<Grave>().type;
            snowman.m_text = snowman.m_text + shapeClue;
            snowmanClueGiven = true;
        }
    }

    public void NewZone()
    {
        grm.ResetTimer();
    }

    public void GameOver()
    {
        if(!gameOver)
        {
            gameOver = true;
			SceneManager.LoadScene("GameOver");
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

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Reload()
    {
        SceneManager.LoadScene("Level");
    }
}
