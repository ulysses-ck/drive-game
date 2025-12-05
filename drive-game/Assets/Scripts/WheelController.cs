using UnityEngine;
using UnityEngine.InputSystem;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAccelerationInput = 0f;
    private float currentTurnInput = 0f;
    private bool isBreaking = false;

    private float currentBreakForce = 0f;

    private void FixedUpdate()
    {
        float motorTorque = acceleration * currentAccelerationInput;
        frontRight.motorTorque = motorTorque;
        frontLeft.motorTorque = motorTorque;

        currentBreakForce = isBreaking ? breakingForce : 0f;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        float currentTurnAngle = maxTurnAngle * currentTurnInput;
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        currentAccelerationInput = context.ReadValue<float>();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        currentTurnInput = context.ReadValue<float>();
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isBreaking = true;
        }
        if (context.canceled)
        {
            isBreaking = false;
        }
    }
}