using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//singleton
public class GameSession : MonoBehaviour
{

    [SerializeField] int freeLives = 3;

    [SerializeField] int score = 0;


    [SerializeField] float deathRestartDelay = 1f;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        livesText.text = freeLives.ToString();
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (freeLives > 1)
        {
            freeLives--;
            StartCoroutine(RestartLevel());
            livesText.text = freeLives.ToString();
        }
        else
        {
            StartCoroutine(NewGame());
        }
    }

    public void ProcessCoinPickup(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    IEnumerator NewGame()
    {
        yield return new WaitForSecondsRealtime(deathRestartDelay);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(deathRestartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
