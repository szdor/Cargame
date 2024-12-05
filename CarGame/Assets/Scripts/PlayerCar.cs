using UnityEngine;

public class PlayerCar : CarBase
{
    public float steeringAngle = 30f;

    protected override void HandleInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float motorTorque = verticalInput * motorForce;

        // Nyomaték alkalmazása (összkerék-hajtás)
        frontLeftWheel.motorTorque = motorTorque;
        frontRightWheel.motorTorque = motorTorque;
        rearLeftWheel.motorTorque = motorTorque;
        rearRightWheel.motorTorque = motorTorque;

        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0f;
        }

        ApplyBraking();
    }

    protected override void Steer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float steer = horizontalInput * steeringAngle;

        frontLeftWheel.steerAngle = steer;
        frontRightWheel.steerAngle = steer;
    }
}
