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

        /// <summary>
        ///     Reset the player's position and velocity to the spawn location when they fall off the level
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            var attachedRigidbody = other.attachedRigidbody;
            attachedRigidbody.position = spawnPoint.position;
            attachedRigidbody.velocity = new Vector3(0, 0, 0);
            attachedRigidbody.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}