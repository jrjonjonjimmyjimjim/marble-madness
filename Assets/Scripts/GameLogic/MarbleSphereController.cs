using Menus;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Controller class for the marble
    ///     Movement logic and other attributes are defined here
    /// </summary>
    public class MarbleSphereController : MonoBehaviour
    {
        public Transform gameCamera;
        public float torque;
        public float maxAngularVelocity;
        public float jumpForce;
        public Rigidbody rb;

        private AudioSource[] _audio;

        private bool _canJump;
        private AudioSource _impact;
        private AudioClip _jumpSound;

        private float _mouseXStart;
        private float _mouseYStart;
        private AudioSource _rolling;

        /// <summary>
        ///     Set default parameters for the marble such as:
        ///     - A maximum angular velocity
        ///     - A flag that checks whether or not the marble can jump
        /// </summary>
        private void Start()
        {
            rb.maxAngularVelocity = maxAngularVelocity;
            _canJump = false;
            _audio = GetComponents<AudioSource>();
            _rolling = _audio[0];
            _impact = _audio[1];
            _jumpSound = (AudioClip)Resources.Load("Sounds/SFX/Jump");
        }

        /// <summary>
        ///     Give players the ability to flick the marble by clicking and dragging the left mouse button,
        ///     as well as the ability to jump, provided that they are on the ground.
        ///     Define noise attributes when the marble is moving.
        /// </summary>
        private void Update()
        {
            // If the game is paused, then don't give the user the ability to move the ball
            if (PauseMenu.isPaused) return;

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

            // Play a jumping sound and pause the rolling sound while the marble is jumping
            if (Input.GetButton("Jump") && _canJump)
            {
                _canJump = false;
                rb.AddForce(new Vector3(0, jumpForce, 0));
                _rolling.Stop();
                _rolling.volume = 1;
                _rolling.pitch = 1;
                _rolling.PlayOneShot(_jumpSound, 1);
            }

            // Play a rolling sound when the marble is rolling along
            if (rb.angularVelocity.magnitude > 0 && _canJump)
            {
                var noise = rb.angularVelocity.magnitude / maxAngularVelocity;
                if (noise > 1) noise = 1;
                _rolling.volume = noise / 2;
                _rolling.pitch = 0.2f;
                if (!_rolling.isPlaying) _rolling.Play();
            }
        }

        /// <summary>
        ///     When the marble comes in contact with the floor, the marble should be able to
        ///     jump
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            _impact.volume = rb.velocity.y / 15;
            _impact.Play();
            _canJump = true;
        }
    }
}