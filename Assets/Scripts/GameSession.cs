using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float reloadLevelDelay = 2f;
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
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
