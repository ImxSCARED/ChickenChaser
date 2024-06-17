using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDropoff : MonoBehaviour
{
    [SerializeField]
    GameManager m_gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            Destroy(other.gameObject);

            m_gameManager.AddScore();
        }
    }
}
