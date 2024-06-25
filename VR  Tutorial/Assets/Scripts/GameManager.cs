using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu,
    GameActive,
    Win
}

public class GameManager : MonoBehaviour
{
    private GameObject m_scoreSceneHelper;

    [SerializeField]
    private TMP_Text m_timerBoard;
    private TMP_Text? m_finalTimeBoard = null;

    private string m_finalTime;

    [SerializeField]
    private float m_timer;
    [SerializeField]
    private float m_score;
    [SerializeField]
    private AudioSource m_pointGain;

    private GameState m_gameState;

    private void Update()
    {
        switch (m_gameState)
        {
            case GameState.GameActive:
                m_timer += Time.deltaTime;

                int timerCeiling = Mathf.CeilToInt(m_timer);
                m_timerBoard.text = (timerCeiling / 60).ToString("D2") + ":" + (timerCeiling % 60).ToString("D2");

                if (m_timer >= 299f)
                {
                    EndGame(false);
                }
                break;
            case GameState.Win:
                if (m_finalTimeBoard == null)
                {
                    m_scoreSceneHelper = GameObject.Find("ScoreSceneHelper");

                    m_scoreSceneHelper.GetComponent<ScoreSceneHelper>().m_finalTimeBoard.text = m_finalTime;

                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }

    public void AddScore()
    {
        m_score++;
        m_pointGain.Play();
        if (m_score >= 5) { EndGame(true); }
    }

    public void StartGame()
    {
        m_gameState = GameState.GameActive;
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            m_gameState = GameState.Win;

            Debug.Log("GAME WIN!");

            m_finalTime = m_timerBoard.text;

            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("ScoreScene");
        }
        else
        {
            m_gameState = GameState.Menu;

            Debug.Log("GAME LOSE...");
            SceneManager.LoadScene("Menu");
        }
    }
}
