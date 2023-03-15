using Menus;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Controller class for the marble
    ///     Movement logic and other attributes are defined here
    /// </summary>

    public enum Powerup {
        None,
        Superjump,
        Superspeed
    };

    public class MarbleSphereController : MonoBehaviour
    {
        public float torque;
        public float maxAngularVelocity;
        public float jumpForce;
        public float superjumpForce;
        public float superspeedForce;
        public Rigidbody rb;
        public Transform gameCamera;
        public Powerup currPowerup;
        private bool _canJump;

        private float _mouseXStart;
        private float _mouseYStart;

        /// <summary>
        ///     Set default parameters for the marble such as:
        ///     - A maximum angular velocity
        ///     - A flag that checks whether or not the marble can jump
        /// </summary>
        private void Start()
        {
            rb.maxAngularVelocity = maxAngularVelocity;
            _canJump = false;
        }

        /// <summary>
        ///     Give players the ability to flick the marble by clicking and dragging the left mouse button,
        ///     as well as the ability to jump, provided that they are on the ground
        /// </summary>
        private void Update()
        {
            // If the game is paused, then don't give the user the ability to move the ball
            if (PauseMenu.IsPaused) return;

            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                _mouseXStart = mousePos.x;
                _mouseYStart = mousePos.y;
            }

            if (Input.GetMouseButtonUp(0))
            {
                var mousePos = Input.mousePosition;
                var forwardAmount = mousePos.y - _mouseYStart;
                var sideAmount = _mouseXStart - mousePos.x;
                rb.AddTorque(gameCamera.forward * (torque * sideAmount));
                rb.AddTorque(gameCamera.right * (torque * forwardAmount));
            }

            if (Input.GetButton("Jump"))
                if (_canJump)
                {
                    _canJump = false;
                    rb.AddForce(new Vector3(0, jumpForce, 0));
                }

            if (Input.GetButton("Fire2"))
            {
                switch (currPowerup) {
                    case Powerup.None:
                        break;
                    case Powerup.Superjump:
                        rb.AddForce(new Vector3(0, superjumpForce, 0));
                        currPowerup = Powerup.None;
                        break;
                    case Powerup.Superspeed:
                        rb.AddForce(gameCamera.forward * superspeedForce);
                        currPowerup = Powerup.None;
                        break;
                }
            }

                
        }

        /// <summary>
        ///     When the marble comes in contact with the floor, the marble should be able to
        ///     jump
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            _canJump = true;
        }
    }
}