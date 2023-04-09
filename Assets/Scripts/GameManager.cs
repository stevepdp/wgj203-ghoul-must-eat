using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            if (instance == null)
            {
                instance = Instantiate(new GameObject("GameManager")).AddComponent<GameManager>();
            }
            return instance;
        }
    }

    int totalGhouls;

    public int TotalGhouls {
        get { return totalGhouls; }
        set { totalGhouls = value; }
    }

    void Awake()
    {
        EnforceSingleInstance();
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDead += GameOver;
        PlayerHealth.OnPlayerHealthIncreased += GhoulCountUpdate;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDead -= GameOver;
        PlayerHealth.OnPlayerHealthIncreased -= GhoulCountUpdate;
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void GhoulCountUpdate(int ghoulCount)
    {
        totalGhouls = ghoulCount;
    }

    public void GameOver()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene != null)
            SceneManager.LoadScene(activeScene.buildIndex + 1, LoadSceneMode.Single);
    }
}