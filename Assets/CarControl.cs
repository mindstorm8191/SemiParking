using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<AxleInfo> axleInfos;

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        Debug.Log(motor);

        foreach (AxleInfo axle in axleInfos) {
            if(axle.steering) {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
            if(axle.motor) {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor;
            }
        }
    }
}

[System.Serializable] public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
