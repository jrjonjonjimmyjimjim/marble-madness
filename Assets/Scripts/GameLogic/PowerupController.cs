using UnityEngine;

namespace GameLogic
{
    public class PowerupController : MonoBehaviour
    {
        public MarbleSphereController marbleSphereController;

        public Powerup powerupType;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        /// <summary>
        ///     When the powerup comes in contact with anything, assume it was the marble,
        ///     then give the marble the powerup
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter(Collider other)
        {
            // TODO: Could put in a check here to make sure the marble was touched
            marbleSphereController.currPowerup = powerupType;
        }
    }
}