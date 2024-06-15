using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class camera_mouse_input : MonoBehaviour
{
    [SerializeField] private float sens = 3.0f;

    private float _rotX;
    private float _rotY;
    private float mouseX;
    private float mouseY;

    [SerializeField] private Transform _target;
    private float _distanceFromTarget = 5.0f;

    // private UnityEngine.Vector3 _currentPos;
    // private UnityEngine.Vector3 _smoothVel = UnityEngine.Vector3.zero;

    // [SerializeField] private float _smoothTime = 0.2f;
    void Start() {
        _target = GameObject.Find("player1").GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X") * sens;
            mouseY = Input.GetAxis("Mouse Y") * sens;

            _rotX += mouseY;
            _rotY += mouseX;

            _rotX = Mathf.Clamp(_rotX, 20, 20);

            transform.localEulerAngles = new UnityEngine.Vector3(33.7f, _rotY, 0);
            transform.position = _target.position - transform.forward * _distanceFromTarget;
        }
    }
}
