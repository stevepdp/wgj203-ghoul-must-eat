using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Start()
    {
        CleanupObjects();
        StartGame();
    }

    void CleanupObjects()
    {
        GameObject[] oldGameManager = GameObject.FindGameObjectsWithTag("GameManager");

        if (oldGameManager.Length > 0)
            Destroy(oldGameManager[0]);
    }

    void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
}