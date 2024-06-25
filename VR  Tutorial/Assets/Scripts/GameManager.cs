using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_timerBoard;

    [SerializeField]
    private float m_timer;
    [SerializeField]
    private float m_score;
    [SerializeField]
    private AudioSource PointGain;

    private bool m_gameActive;

    private void Update()
    {
        if (m_gameActive)
        {
            
            m_timer += Time.deltaTime;

            int timerCeiling = Mathf.CeilToInt(m_timer);
            m_timerBoard.text = (timerCeiling / 60).ToString("D2") + ":" + (timerCeiling % 60).ToString("D2");

            if (m_timer >= 299f)
            {
                EndGame(false);
                m_gameActive = false;
            }
        }
    }

    public void AddScore()
    {

        m_score++;
        PointGain.Play();
        if (m_score >= 5) { EndGame(true); }
    }

    public void StartGame()
    {
        m_gameActive = true;
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            Debug.Log("GAME WIN!");
            SceneManager.LoadScene("ScoreScene");
            
        }
        else
        {
            Debug.Log("GAME LOSE...");
            SceneManager.LoadScene("Menu");
        }
    }
}
