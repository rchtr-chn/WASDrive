using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedCarRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        dragging = true;

        float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // For Rigidbody rotation
        if (rb != null)
        {
            rb.AddTorque(Vector3.down * x);
        }
        else // For transform rotation
        {
            transform.RotateAround(Vector3.down, x);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void FixedUpdate()
    {
        if (dragging && rb != null)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            rb.AddTorque(Vector3.down * x);
        }
    }
}
