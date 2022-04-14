using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float loadNextLevelDelay = 1f;
    [SerializeField] int levelCompletePoints = 100;
    bool levelIsComplete;


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !levelIsComplete)
        {
            levelIsComplete = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {   
        FindObjectOfType<GameSession>().AddToScore(levelCompletePoints);
        yield return new WaitForSecondsRealtime(loadNextLevelDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int maxSceneIndex = SceneManager.sceneCountInBuildSettings;

        if(nextSceneIndex == maxSceneIndex)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene (nextSceneIndex);
    }
    
}
