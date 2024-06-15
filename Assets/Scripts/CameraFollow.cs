using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    void Start() {
        objectToFollow = GameObject.Find("player1").GetComponent<Transform>();
    }

    public void LookAtTarget()
    {
        UnityEngine.Vector3 _lookDirection = objectToFollow.position - transform.position;
        UnityEngine.Quaternion _rot = UnityEngine.Quaternion.LookRotation(_lookDirection, UnityEngine.Vector3.up);
        transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        UnityEngine.Vector3 _targetPos = objectToFollow.position +
                             objectToFollow.forward * -3 +
                             objectToFollow.right * offset.x +
                             objectToFollow.up * 2;
        transform.position = UnityEngine.Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        if(Input.GetMouseButton(1) == false)
        {
            LookAtTarget();
            MoveToTarget();
        }
    }

    public Transform objectToFollow;
    public UnityEngine.Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 75;
}
