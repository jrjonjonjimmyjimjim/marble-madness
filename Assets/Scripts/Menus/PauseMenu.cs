using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    /// <summary>
    ///     Implement the pause menu functionality to return to the main menu
    ///     or to pause the game
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        public static bool isPaused;
        public GameObject pauseMenu;
        public GameObject settingsMenu;
        public AudioSource _audio;

        /// <summary>
        ///     Pause the game by setting the timescale to 0 or else to 1 as normal
        ///     Use the escape key to toggle the pause
        /// </summary>
        private void Update()
        {
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;

            // Small quality of life that allows you to escape out of the settings menu
            if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
        }

        /// <summary>
        ///     Negate the current value of the paused boolean
        /// </summary>
        public void TogglePause(bool music = true)
        {
            isPaused = !isPaused;
            if(music)
            {
                _audio.Play();
            }
        }

        /// <summary>
        ///     Return to the main menu
        /// </summary>
        public void ShowMenu()
        {
            Time.timeScale = 1f;
            TogglePause(false);
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        ///     Quit the game
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }
    }
}