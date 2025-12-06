using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider[] WCs;
    [SerializeField] public GameObject[] wheels;
    public float torque = 200f;
    public float maxSteerAngle = 30;

    private float currentAccelerationInput = 0f;
    private float currentSteer = 0f;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        Go(currentAccelerationInput, currentSteer);
    }

    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1f, 1f);
        steer = Mathf.Clamp(steer, -1f, 1f) * maxSteerAngle;

        float thrustTorque = accel * torque;
        for(int i = 0; i < wheels.Length; i++)
        {
            WCs[i].motorTorque = thrustTorque;

            if (i<2)
                WCs[i].steerAngle = steer;

            Quaternion quat;
            Vector3 position;

            WCs[i].GetWorldPose(out position, out quat);

            wheels[i].transform.position = position;
            wheels[i].transform.rotation = quat;
        }
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        currentAccelerationInput = context.ReadValue<float>();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        currentSteer = context.ReadValue<float>();
    }
}