using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private const string SCENE_LEVELS = "Levels";
    private const string SCENE_MAIN_MENU = "MainMenu";

    public void Init ()
    {
        SceneManager.LoadScene(SCENE_LEVELS);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(SCENE_MAIN_MENU);
    }

    public void Back()
    {
        SceneManager.LoadScene(SCENE_MAIN_MENU);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }
}
