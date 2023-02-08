using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marble_sphere_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float torque;
    public Rigidbody rb;
    public Transform gameCamera;

    private float mouseXStart;
    private float mouseYStart;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*
        if (Input.GetKey("w")) {
            rb.AddTorque(gameCamera.right * torque);
        }
        if (Input.GetKey("a")) {
            rb.AddTorque(gameCamera.forward * torque);
        }
        if (Input.GetKey("s")) {
            rb.AddTorque(gameCamera.right * torque * -1);
        }
        if (Input.GetKey("d")) {
            rb.AddTorque(gameCamera.forward * torque * -1);
        }
        */

        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            mouseXStart = mousePos.x;
            mouseYStart = mousePos.y;
        }

        if (Input.GetMouseButtonUp(0)) {
            Vector3 mousePos = Input.mousePosition;
            float forwardAmount = mousePos.y - mouseYStart;
            float sideAmount = mouseXStart - mousePos.x;
            rb.AddTorque(gameCamera.forward * torque * sideAmount);
            rb.AddTorque(gameCamera.right * torque * forwardAmount);
        }
    }
}
