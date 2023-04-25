using GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Camera
{
    /// <summary>
    ///     Controller for the HUD
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        public TMP_Text Scene_Text;
        public TMP_Text GameMode_Text;
        public TMP_Text Gameplay_Text;
        public TMP_Text Powerup_Text;

        // Set the text for the HUD based the current scene and game mode
        private void Start()
        {
            Scene_Text.text = SceneManager.GetActiveScene().name;
            GameMode_Text.text = GameModeManager.GameMode switch
            {
                GameMode.Survival => "Survival",
                GameMode.Time => "Time Attack",
                GameMode.Tutorial => "Tutorial",
                GameMode.Level => "Single Level",
                GameMode.Menu or _ => "",
            };

            Gameplay_Text.text = GameModeManager.GameMode switch
            {
                GameMode.Time => "Time: " + GameManager.timer,
                GameMode.Survival => "Lives: " + GameManager.lives,
                _ => ""
            };
        }

        /// <summary>
        ///     Update the lives or timer text based on the selected game mode
        /// </summary>
        private void Update()
        {
            GameManager.CheckStatus();
            Gameplay_Text.text = GameModeManager.GameMode switch
            {
                GameMode.Time => "Time: " + GameManager.timer.ToString("F2"),
                GameMode.Survival => "Lives: " + GameManager.lives,
                _ => Gameplay_Text.text
            };

            Powerup_Text.text = MarbleSphereController.currPowerUp switch
            {
                PowerUp.None => "No Powerup",
                PowerUp.SuperJump => "Superjump",
                PowerUp.SuperSpeed => "Superspeed",
                _ => "No Powerup"
            };
        }
    }
}