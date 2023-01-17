using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject Wall;
    public float SpawnTime;
    float m_spawntime;
    int m_score;
    bool m_isGameOver;
    bool m_isStartGame;
    UI m_ui;
    public AudioSource Aus;
    public AudioClip soundTag;
    public AudioClip soundLose;
    

    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m_ui = FindObjectOfType<UI>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawntime = m_spawntime - Time.deltaTime;
        if (m_isGameOver)
        {
            m_spawntime = 0;
            return;
        }
        if (m_spawntime <= 0)
        {
            SpawnWall();
            m_spawntime = SpawnTime;
        }
    }
    public void SpawnWall()
    {
        if (m_isGameOver == false && m_isStartGame)
        {
            float Ypos = Random.Range(-3.24f, -0.87f);
            Vector2 spawnWall = new Vector2(12.1f, Ypos);
            if (Wall)
            {
                Instantiate(Wall, spawnWall, Quaternion.identity);
            }
        }
        else return;
        
    }
    public void RePlay()
    {
        m_score = 0;
        m_isGameOver = false;
        m_ui.SetScoreText("Score:");
        m_ui.ShowPanel(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        m_isStartGame = true;
        IsStartGame();
        m_ui.ClosePanel1(false);
        Time.timeScale = 1;
    }
    public bool IsStartGame()
    {
        return true;
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrease()
    {
        if (m_isGameOver)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
        if (Aus && soundTag)
        {
            Aus.PlayOneShot(soundTag);
        }
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }
    public bool SetGameOver()
    {
        return m_isGameOver;
    }
    public void GetGameOver(bool State)
    {
        if (Aus && soundLose && m_isGameOver == false)
        {
            Aus.PlayOneShot(soundLose);
        }
        m_isGameOver = State;
    }
}
