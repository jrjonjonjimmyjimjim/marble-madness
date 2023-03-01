using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marble_sphere_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float torque;
    public float maxAngularVelocity;
    public float jumpForce;
    public Rigidbody rb;
    public Transform gameCamera;

    private float mouseXStart;
    private float mouseYStart;

    private bool canJump;

    void Start()
    {
        rb.maxAngularVelocity = maxAngularVelocity;
        canJump = false;
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

        if (Input.GetButton("Jump")) {
            if (canJump) {
                canJump = false;
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        canJump = true;
    }
}
