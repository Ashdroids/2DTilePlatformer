using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float reloadLevelDelay = 2f;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score;
    
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

    void Start() 
    {
        livesText.text = playerLives.ToString();
        
    }

    void Update() 
    {
        scoreText.text = score.ToString();
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
            StartCoroutine(ReloadScene());
        }
        else
        {
            ResetGameSession();
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(reloadLevelDelay);
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
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
