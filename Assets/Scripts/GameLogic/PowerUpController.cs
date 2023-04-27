using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Give the player a powerup when they collide with it
    /// </summary>
    public class PowerUpController : MonoBehaviour
    {
        public MarbleSphereController marbleSphereController;

        public PowerUp powerUpType;

        public AudioSource powerUpSound;

        /// <summary>
        ///     When the powerup comes in contact with anything, assume it was the marble,
        ///     then give the marble the powerup
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                MarbleSphereController.currPowerUp = powerUpType;
                powerUpSound.Play();
            }
        }
    }
}