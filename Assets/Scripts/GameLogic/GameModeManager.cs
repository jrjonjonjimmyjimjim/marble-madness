using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Define the different game modes
    /// </summary>
    public enum GameMode
    {
        Tutorial,
        Level,
        Time,
        Survival,
        Menu
    }

    /// <summary>
    ///     Tracks the current game mode
    /// </summary>
    public class GameModeManager : MonoBehaviour
    {
        public static GameModeManager Instance;
        public static GameMode GameMode;

        private void Awake()
        {
            Instance = this;
        }


        /// <summary>
        ///     TODO: fill this in
        /// </summary>
        /// <param name="newMode"></param>
        public static void UpdateGameMode(GameMode newMode)
        {
            GameMode = newMode;
        }
    }
}