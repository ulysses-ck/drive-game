using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int unlockedLevels = GetUnlockedLevelsCount();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i < unlockedLevels);
        }

        if (unlockedLevels > 0)
        {
            levelButtons[unlockedLevels - 1].Select();
        }
    }

    int GetUnlockedLevelsCount()
    {
        return PlayerPrefs.GetInt("UnlockedLevels", 3);
    }
}
