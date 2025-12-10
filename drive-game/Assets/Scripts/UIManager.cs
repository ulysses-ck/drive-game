using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private const string SCENE_LEVELS = "Levels";
    public void Init ()
    {
        SceneManager.LoadScene(SCENE_LEVELS);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
