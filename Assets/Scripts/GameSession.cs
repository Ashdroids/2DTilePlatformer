using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float reloadDelay = 2f;
    [SerializeField] float gameOverDelay = 4f;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip gameOverSFX;
    
    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }    
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    void Update() 
    {
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + playerLives.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
            GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Invoke("ReloadScene", reloadDelay);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(gameOverSFX);
            Invoke("ResetGameSession", gameOverDelay);
        }
    }

    void ReloadScene()
    {
        int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneindex);
    }

    void TakeLife()
    {
        playerLives --;
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
