using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     TODO: Fill this in
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
    /// </summary>
    public class GameModeManager : MonoBehaviour
    {
        public static GameModeManager Instance;
        public static GameMode GameMode;

        // public static event Action<GameMode> OnGameModeChanged;

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

            // switch(GameMode) {
            //     case GameMode.Tutorial:
            //         break;
            //     case GameMode.Level:
            //         break;
            //     case GameMode.Menu:
            //         break;
            //     case GameMode.Time:
            //         break;
            //     case GameMode.Survival:
            //         break;
            // }

            // OnGameModeChanged?.Invoke(newMode);
        }
    }
}