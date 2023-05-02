using UnityEngine;
using UnityEngine.UI;

public class HUDGhoulCount : MonoBehaviour
{
    const string GHOUL_COUNT_PREFIX = "GHOULS: ";

    Text ghoulCountText;

    void Awake()
    {
        ghoulCountText = GetComponent<Text>();
    }

    void Start()
    {
        SetGhoulCount();
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerGrowth += SetGhoulCount;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerGrowth -= SetGhoulCount;
    }

    void SetGhoulCount()
    {
        if (ghoulCountText != null && GameManager.Instance != null)
            ghoulCountText.text = GHOUL_COUNT_PREFIX + GameManager.Instance.TotalGhouls.ToString();
    }
}
