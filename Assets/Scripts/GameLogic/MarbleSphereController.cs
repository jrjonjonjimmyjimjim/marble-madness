using Menus;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Controller class for the marble
    ///     Movement logic and other attributes are defined here
    /// </summary>
    public enum PowerUp
    {
        None,
        SuperJump,
        SuperSpeed
    }

    public class MarbleSphereController : MonoBehaviour
    {
        public float torque;
        public int minY = -50;
        public float maxAngularVelocity;
        public float jumpForce;
        public float superJumpForce = 5000f;
        public float superSpeedForce = 10000f;
        public Rigidbody rb;
        public Transform gameCamera;
        public static PowerUp currPowerUp;

        private AudioSource[] _audio;

        private bool _canJump;
        private AudioSource _impact;
        private AudioClip _jumpSound;
        private AudioSource _death;

        private float _mouseXStart;
        private float _mouseYStart;
        private AudioSource _rolling;
        private Vector3 spawnPoint;

        /// <summary>
        ///     Set default parameters for the marble such as:
        ///     - A maximum angular velocity
        ///     - A flag that checks whether or not the marble can jump
        ///     - Sound effects
        ///     - The spawn point
        /// </summary>
        private void Start()
        {
            rb.maxAngularVelocity = maxAngularVelocity;
            _canJump = false;
            _audio = GetComponents<AudioSource>();
            _rolling = _audio[0];
            _impact = _audio[1];
            _death = _audio[2];
            _jumpSound = (AudioClip)Resources.Load("Sounds/SFX/Jump");
            spawnPoint = rb.position;
        }

        /// <summary>
        ///     Give players the ability to flick the marble by clicking and dragging the left mouse button,
        ///     as well as the ability to jump, provided that they are on the ground.
        ///     Define noise attributes when the marble is moving.
        /// </summary>
        private void Update()
        {
            // If the game is paused, then don't give the user the ability to move the ball
            if (PauseMenu.isPaused)
            {
                _rolling.Stop();
                return;
            }

            // If the marble has fallen too far, then respawn it
            if (rb.position.y < minY)
            {
                Respawn();
            }
            else if (rb.position.y < -1 && _rolling.isPlaying)
            {
                _canJump = false;
                _rolling.Stop();
            }


            // Save the mouse position when the left mouse button is clicked and released to determine the direction of
            // the flick
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

            // Play a rolling sound when the marble is moving
            if (rb.angularVelocity.magnitude > 0 && _canJump)
            {
                var noise = rb.angularVelocity.magnitude / maxAngularVelocity;
                if (noise > 0.7) noise = (float)7 / 10;

                _rolling.volume = noise;
                _rolling.pitch = noise;
                if (!_rolling.isPlaying) _rolling.Play();
            }

            if (Input.GetButton("Fire3"))
                // TODO: We may want powerups to freeze motion first, then add force.
                switch (currPowerUp)
                {
                    case PowerUp.None:
                        break;
                    case PowerUp.SuperJump:
                        rb.AddForce(new Vector3(0, superJumpForce, 0));
                        currPowerUp = PowerUp.None;
                        break;
                    case PowerUp.SuperSpeed:
                        rb.AddForce(gameCamera.forward * superSpeedForce);
                        currPowerUp = PowerUp.None;
                        break;
                }
        }

        /// <summary>
        ///     When the marble comes in contact with the floor, the marble should be able to jump
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            _impact.volume = rb.velocity.y / 10;
            _impact.Play();
            if (collision.gameObject.tag == "Floor") _canJump = true;
            if (collision.gameObject.tag == "Obstacle" && GameModeManager.GameMode == GameMode.Survival) Respawn();
        }

        /// <summary>
        ///     Move the marble in the direction of the hit
        /// </summary>
        /// <param name="hitDir"></param>
        public void HitPlayer(Vector3 hitDir)
        {
            if (GameModeManager.GameMode != GameMode.Survival) {
                hitDir.y = 0;
                rb.AddForce(hitDir);
            }
        }

        /// <summary>
        ///     When the marble falls too far, it should respawn at the spawn point
        /// </summary>
        private void Respawn()
        {
            GameManager.lives--;
            _rolling.Stop();
            _death.Play();
            rb.position = spawnPoint;
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            currPowerUp = PowerUp.None;
        }
    }
}