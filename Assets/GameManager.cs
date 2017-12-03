using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrimReaperManager))]
public class GameManager : MonoBehaviour {

    public static GameManager instance;

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
    }

    public void NewZone()
    {
        grm.ResetTimer();
    }
}
