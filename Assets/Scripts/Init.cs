using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Start()
    {
        DestroyOldObjects();
        StartGame();
    }

    void DestroyOldObjects()
    {
        GameObject[] FullScreenManager = GameObject.FindGameObjectsWithTag("FullScreenManager");
        GameObject[] GameManager = GameObject.FindGameObjectsWithTag("GameManager");

        if (FullScreenManager.Length > 0)
            Destroy(FullScreenManager[0]);

        if (GameManager.Length > 0)
            Destroy(GameManager[0]);
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
