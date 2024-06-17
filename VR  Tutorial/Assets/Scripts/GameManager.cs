using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_timerBoard;

    [SerializeField]
    private float m_timer;
    [SerializeField]
    private float m_score;

    private bool m_gameActive;

    private void Update()
    {
        if (m_gameActive)
        {
            m_timer -= Time.deltaTime;

            int timerCeiling = Mathf.CeilToInt(m_timer);
            m_timerBoard.text = (timerCeiling / 60).ToString("D2") + ":" + (timerCeiling % 60).ToString("D2");

            if (m_timer <= 0)
            {
                Debug.Log("GAME END");
                m_gameActive = false;
            }
        }
    }

    public void AddScore()
    {
        m_score++;
    }

    public void StartGame()
    {
        m_gameActive = true;
    }
}
