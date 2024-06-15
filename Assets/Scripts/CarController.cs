using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public void GetInput()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontal;
        frontRightWheel.steerAngle = m_steeringAngle;
        frontLeftWheel.steerAngle = m_steeringAngle;
    }

    // private void Accelerate()
    // {
    //     backRightWheel.motorTorque *= m_vertical;
    //     backLeftWheel.motorTorque *= m_vertical;
    // }

    private void isOnGear()
    {
        backRightWheel.brakeTorque = 0f;
        backLeftWheel.brakeTorque = 0f;

        backRightWheel.motorTorque = 0.75f * motorForce;
        backLeftWheel.motorTorque = 0.75f * motorForce;

        if(m_vertical > 0)
        {
            backRightWheel.motorTorque *= m_vertical * 6f;
            backLeftWheel.motorTorque *= m_vertical * 6f;            
        }       
    }

    private void isNeutral()
    {
        backRightWheel.brakeTorque = 0f;
        backLeftWheel.brakeTorque = 0f;

        backRightWheel.motorTorque -= backRightWheel.motorTorque * 0.25f;
        backLeftWheel.motorTorque -= backLeftWheel.motorTorque * 0.25f;
    }
    private void isReverse()
    {
        backRightWheel.brakeTorque = 0f;
        backLeftWheel.brakeTorque = 0f;

        backRightWheel.motorTorque = -0.75f * motorForce;
        backLeftWheel.motorTorque = -0.75f * motorForce;

        if(m_vertical < 0)
        {
            backRightWheel.motorTorque *= m_vertical * 6f * -1f;
            backLeftWheel.motorTorque *= m_vertical * 6f * -1f;            
        }         
    }

    private void isParking()
    {
        backRightWheel.motorTorque = 0f;
        backLeftWheel.motorTorque = 0f;

        backRightWheel.brakeTorque = 1000f;
        backLeftWheel.brakeTorque = 1000f;        
    }

    private void isBraking()
    {
        backRightWheel.motorTorque = 0f;
        backLeftWheel.motorTorque = 0f;

        backRightWheel.brakeTorque = brakeStrength;     
        backLeftWheel.brakeTorque = brakeStrength;  
    }
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontRightWheel, frontRightT);
        UpdateWheelPose(frontLeftWheel, frontLeftT);
        UpdateWheelPose(backRightWheel, backRightT);
        UpdateWheelPose(backLeftWheel, backLeftT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    void Start()
    {
        logic = GameObject.Find("Logic").GetComponent<changeSceneScript>();
        controlsInput = GetComponent<CarController>();
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();

        if(Input.GetKey(KeyCode.Space))
        {
            isBraking();
        }
        else if(gearNum == 1)
        {
            isOnGear();
        }
        else if(gearNum == 0)
        {
            isNeutral();
        }
        else if(gearNum == -1)
        {
                isReverse();
        }
        else if(gearNum == -2)
        {
            isParking();
        }

        UpdateWheelPoses();
    }

    private void Update()
    {
        if(gearNum < 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                gearNum+=1;
            }
        }

        if(gearNum > -2)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                gearNum-=1;
            }
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Crash")
        {
            logic.gameOver();
            controlsInput.enabled = false;
        }
    }
    private float m_horizontal;
    private float m_vertical;
    private float m_steeringAngle;

    public WheelCollider frontRightWheel, frontLeftWheel;
    public WheelCollider backRightWheel, backLeftWheel;
    public Transform frontRightT, frontLeftT;
    public Transform backRightT, backLeftT;
    private float maxSteerAngle = 20f;
    private float motorForce = 45f;

    private changeSceneScript logic;
    private CarController controlsInput;
    public int gearNum = 0;

    public float brakeStrength = 500f;
    
}
