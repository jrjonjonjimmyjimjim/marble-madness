using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_floor_controller : MonoBehaviour
{

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        other.attachedRigidbody.position = spawnPoint.position;
        other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
        other.attachedRigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
}
