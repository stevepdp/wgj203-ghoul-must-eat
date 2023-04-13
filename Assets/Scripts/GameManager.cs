using System;
using System.Collections;
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

    public static event Action OnGameOver;
    public static event Action<string> OnTimerUpdate;

    const byte SECONDS_PER_MINUTE = 60;
    const byte TIMER_UPDATE_INTERVAL = 1;
    const string TIMER_TIME_FORMAT = "{0:00}:{1:00}";

    Coroutine timerCoroutine;
    byte totalGhouls = 1;
    float elapsedTime;
    string elapsedTimeFormatted;

    public float ElapsedTime
    {
        get { return elapsedTime; }
    }

    public string ElapsedTimeFormatted
    {
        get { return elapsedTimeFormatted; }
    }

    public byte TotalGhouls
    {
        get { return totalGhouls; }
        set { totalGhouls = value; }
    }

    void Awake()
    {
        EnforceSingleInstance();
    }

    void Start()
    {
        GameSetup();
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDead += GameOver;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDead -= GameOver;
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / SECONDS_PER_MINUTE);
            int seconds = Mathf.FloorToInt(elapsedTime % SECONDS_PER_MINUTE);

            elapsedTimeFormatted = string.Format(TIMER_TIME_FORMAT, minutes, seconds);
            OnTimerUpdate?.Invoke(elapsedTimeFormatted);

            yield return new WaitForSeconds(TIMER_UPDATE_INTERVAL);

            elapsedTime += TIMER_UPDATE_INTERVAL;
        }
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void GameSetup()
    {
        timerCoroutine = StartCoroutine(UpdateTimer());
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();

        StopCoroutine(timerCoroutine);

        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene != null)
            SceneManager.LoadScene(activeScene.buildIndex + 1, LoadSceneMode.Single);
    }
}