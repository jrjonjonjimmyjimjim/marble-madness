using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Controller for the bottom of the level, which resets the player's
    ///     when the player has fallen too far
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
}