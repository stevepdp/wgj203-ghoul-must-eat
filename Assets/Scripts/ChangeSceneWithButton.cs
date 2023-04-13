using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    byte SCENE_INIT = 0;

    public void LoadInitScene() => SceneManager.LoadScene(SCENE_INIT);

    public void LoadScene(string name) => SceneManager.LoadScene(name);
}
