using UnityEngine;
using UnityEngine.UI;

public class ExitToOS : MonoBehaviour
{
#if UNITY_STANDALONE
    [SerializeField] Text exitButtonText;
#endif

    void Awake()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        gameObject.SetActive(false);
#endif
#if UNITY_STANDALONE_WIN
        if (exitButtonText != null) exitButtonText.text = "Exit to Windows";
#elif UNITY_STANDALONE_OSX
        if (exitButtonText != null) exitButtonText.text = "Exit to macOS";
#elif UNITY_STANDALONE_LINUX
        if (exitButtonText != null) exitButtonText.text = "Exit to Linux";
#endif
    }

#if UNITY_STANDALONE
    public void ExitToDesktop() => Application.Quit();
#endif
}
