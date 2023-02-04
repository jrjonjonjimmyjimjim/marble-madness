using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marble_center_controller : MonoBehaviour
{
    public Transform marbleSphere;
    public float pLerp = .02f;
    public Vector2 turn;
    public float sensitivity = .5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = marbleSphere.position;

        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
