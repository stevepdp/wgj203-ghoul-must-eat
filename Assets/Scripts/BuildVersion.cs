using TMPro;
using UnityEngine;

public class BuildVersion : MonoBehaviour
{
    TMP_Text buildVersionText;

    void Awake()
    {
        buildVersionText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        SetVersionText();
    }

    void SetVersionText()
    {
        if (buildVersionText != null)
            buildVersionText.text = "v" + Application.version;
    }
}
