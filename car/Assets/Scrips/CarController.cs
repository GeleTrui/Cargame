using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private float horizontalinput;
    private float currentsteerangle;
    private float verticalinput;
    private float currentbreakforce;
    private bool isBreaking;
    [SerializeField] private float breakforce;
    [SerializeField] private float motorforce;
    [SerializeField] private float maxSteer;
    [SerializeField] private WheelCollider FrontLeftCollider;
    [SerializeField] private WheelCollider FrontRightCollider;
    [SerializeField] private WheelCollider BackLeftCollider;
    [SerializeField] private WheelCollider BackRightCollider;
    [SerializeField] private Transform FrontLeftTransform;
    [SerializeField] private Transform FrontRightTransform;
    [SerializeField] private Transform BackLeftTransform;
    [SerializeField] private Transform BackRightTransform;
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void HandleMotor()
    {
       
        FrontLeftCollider.motorTorque = verticalinput * motorforce;
        FrontRightCollider.motorTorque = verticalinput * motorforce;
        currentbreakforce = isBreaking ? breakforce : 0f;
        if (isBreaking)
        {
            applybreaking();
        }


    }
    private void applybreaking()
    {
        FrontLeftCollider.brakeTorque = currentbreakforce;
        FrontRightCollider.brakeTorque = currentbreakforce;
        BackLeftCollider.brakeTorque = currentbreakforce;
        BackRightCollider.brakeTorque = currentbreakforce;
    }
    
    private void HandleSteering()
    {
        currentsteerangle = maxSteer * horizontalinput;
        FrontLeftCollider.steerAngle = currentsteerangle;
        FrontRightCollider.steerAngle = currentsteerangle;
    }
   
    private void GetInput()
    {
        horizontalinput = Input.GetAxis(horizontal);
        verticalinput = Input.GetAxisRaw(vertical);
        isBreaking = Input.GetKeyDown(KeyCode.Space);
    }
    private void UpdateWheels()
    {
        updatesinglewheel(FrontLeftCollider, FrontLeftTransform);
        updatesinglewheel(FrontRightCollider, FrontRightTransform);
        updatesinglewheel(BackLeftCollider, BackLeftTransform);
        updatesinglewheel(BackRightCollider, BackRightTransform);
    }
    private void updatesinglewheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
        
    }
}
