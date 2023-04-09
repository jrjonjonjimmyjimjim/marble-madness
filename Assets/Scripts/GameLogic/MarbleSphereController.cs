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

            if(rb.angularVelocity.magnitude > 0 && _canJump)
            {
                float noise = rb.angularVelocity.magnitude / (maxAngularVelocity);
                if(noise > 0.7)
                {
                    noise = (float)7/10;
                }
                
                _rolling.volume = noise;
                _rolling.pitch = noise;
                if (!_rolling.isPlaying)
                {
                    _rolling.Play();
                }
            }
            
            if (Input.GetButton("Fire2"))
            {
                // TODO: We may want powerups to freeze motion first, then add force.
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
        ///

        private void OnCollisionEnter(Collision collision){
            if (!_canJump)
            {
                _impact.volume = rb.velocity.y / 10;
                _impact.Play();
            }
            if(collision.gameObject.tag == "Floor")
            {
                _canJump = true;
            }
        }
    }
}