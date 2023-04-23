using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text ghoulCountText;
    [SerializeField] Text survivedTimeText;

    const string GHOUL_COUNT_PREFIX = "You grew a horde of ";
    const string SURVIVE_TIME_PREFIX = "You survived: ";

    void Start()
    {
        SetGameoverText();
    }

    void SetGameoverText()
    {
        if (GameManager.Instance != null)
        {
            string ghoulCountSuffix = "";
            if (GameManager.Instance.TotalGhouls <= 1)
                ghoulCountSuffix = " ghoul.";
            else
                ghoulCountSuffix = " ghouls.";

            if (ghoulCountText != null)
                ghoulCountText.text = GHOUL_COUNT_PREFIX + GameManager.Instance.TotalGhouls.ToString() + ghoulCountSuffix;

            if (survivedTimeText != null)
                survivedTimeText.text = SURVIVE_TIME_PREFIX + GameManager.Instance.ElapsedTimeWords + ".";
        }
    }
}
