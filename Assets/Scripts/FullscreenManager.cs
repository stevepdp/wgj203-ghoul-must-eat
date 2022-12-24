using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenManager : MonoBehaviour
{
    int height = 720;
    int width = 1280;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        ToggleFullScreen();
    }

    void ToggleFullScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableFullScreen();
        }

        if ((Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F)) ||
            (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F)) ||
            (Input.GetKey(KeyCode.LeftCommand) && Input.GetKeyDown(KeyCode.F))) {

            if (Screen.fullScreen)
            {
                DisableFullScreen();
            }
            else
            {
                EnableFullScreen();
            }
        }
    }

    void DisableFullScreen()
    {
        Screen.SetResolution(width, height, false);
    }

    void EnableFullScreen()
    {
        Screen.SetResolution(width, height, true);
    }
}
