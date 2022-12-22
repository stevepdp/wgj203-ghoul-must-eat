using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private string _sceneName;

    [SerializeField]
    private int _totalGhouls;
    [SerializeField]
    private float _totalSecondsSurvived;

    void Awake()
    {
        // for object persistance
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public string GetSurviveTime()
    {
        return _totalSecondsSurvived.ToString();
    }

    public string GetTotalGhouls()
    {
        return _totalGhouls.ToString();
    }

      public void UpdateHordeCount(int count)
    {
        _totalGhouls = count;
    }

    public void UpdateSecondsSurvived(float seconds)
    {
        _totalSecondsSurvived = seconds;
    }

    public void OnGameOver()
    {
        Debug.Log("GameOver condition met");
        SceneManager.LoadScene("99_Results");
    }
}