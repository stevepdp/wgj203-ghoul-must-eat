using UnityEngine;
using UnityEngine.UI;

public class HUDTimeElapsed : MonoBehaviour
{
    const string TIME_ELAPSED_PREFIX = "TIME: ";

    Text timeElapsedText;

    void Awake()
    {
        timeElapsedText = GetComponent<Text>();
    }

    void OnEnable()
    {
        GameManager.OnTimerUpdate += UpdateTimeElapsed;
    }

    void OnDisable()
    {
        GameManager.OnTimerUpdate -= UpdateTimeElapsed;
    }

    void UpdateTimeElapsed(string time)
    {
        if (timeElapsedText != null && GameManager.Instance != null)
            timeElapsedText.text = TIME_ELAPSED_PREFIX + time;
    }
}
