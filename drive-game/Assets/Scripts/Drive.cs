using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider[] WCs;
    [SerializeField] public GameObject[] wheels;
    public float torque = 200f;
    public float maxSteerAngle = 30;
    public float steerSmoothSpeed = 10f;
    public float maxBrakeTorque = 500;

    private float currentAccelerationInput = 0f;
    private float currentSteer = 0f;
    private float currentBrakeTorque = 0f;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        Go(currentAccelerationInput, currentSteer, currentBrakeTorque);
    }

    void Go(float accel, float steer, float brake)
    {
        float targetSteerAngle = steer * maxSteerAngle;

        accel = Mathf.Clamp(accel, -1f, 1f);

        float thrustTorque = accel * torque;
        for(int i = 0; i < wheels.Length; i++)
        {
            float currentSteerAngle = WCs[i].steerAngle;
            float smoothedSteer = Mathf.Lerp(
                currentSteerAngle,
                targetSteerAngle,
                Time.fixedDeltaTime * steerSmoothSpeed
                );
            brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

            WCs[i].motorTorque = thrustTorque;

            if (i < 2)
                WCs[i].steerAngle = smoothedSteer;
            else
                WCs[i].brakeTorque = brake;

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

    public void OnBrake(InputAction.CallbackContext context)
    {
        currentBrakeTorque = context.ReadValue<float>();
    }
}