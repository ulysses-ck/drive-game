using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;

    public float torque = 200f;

    private float currentAccelerationInput = 0f;

    void Start()
    {
        if (wheelCollider == null)
        {
            wheelCollider = GetComponent<WheelCollider>();
        }
    }

    private void FixedUpdate()
    {
        Go(currentAccelerationInput);
    }

    void Go(float accel)
    {
        accel = Mathf.Clamp(accel, -1f, 1f);

        float thrustTorque = accel * torque;
        wheelCollider.motorTorque = thrustTorque;
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        currentAccelerationInput = context.ReadValue<float>();
    }
}