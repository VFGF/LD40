using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomizedMovement))]
public class Brain : MonoBehaviour {

    private RandomizedMovement m_rm;

    void Start()
    {
        m_rm = GetComponent<RandomizedMovement>();
    }
}
