using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    private int activeCameraIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCameraSwitch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            activeCameraIndex = (activeCameraIndex + 1) % cameras.Length;
            SwitchToCamera(activeCameraIndex);
        }
    }

    private void SwitchToCamera(int index)
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            bool isActive = (i == index);
            cameras[i].SetActive(isActive);
        }
    }
}
