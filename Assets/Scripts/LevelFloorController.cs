using UnityEngine;

/// <summary>
///     TODO: Fill this in
/// </summary>
public class LevelFloorController : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        var attachedRigidbody = other.attachedRigidbody;
        attachedRigidbody.position = spawnPoint.position;
        attachedRigidbody.velocity = new Vector3(0, 0, 0);
        attachedRigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
}