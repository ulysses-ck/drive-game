using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectFirstButton : MonoBehaviour
{
    public Button firstSelectedButton;
    private GameObject lastSelected;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
    }
}
