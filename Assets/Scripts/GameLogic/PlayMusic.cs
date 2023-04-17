using UnityEngine;

namespace GameLogic
{
    /// <summary>
    ///     Controller for music playback
    /// </summary>
    public class PlayMusic : MonoBehaviour
    {
        public static PlayMusic Instance;
        public static AudioSource audio;
        private AudioClip _backgroundMusic;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        ///     Set the background music based on the current game mode
        /// </summary>
        private void Start()
        {
            audio = GetComponent<AudioSource>();
            _backgroundMusic = GameModeManager.GameMode switch
            {
                GameMode.Tutorial => (AudioClip)Resources.Load("Sounds/Background/Tutorial"),
                GameMode.Level => (AudioClip)Resources.Load("Sounds/Background/Level"),
                GameMode.Time => (AudioClip)Resources.Load("Sounds/Background/Time Attack"),
                GameMode.Survival => (AudioClip)Resources.Load("Sounds/Background/Survival"),
                _ => _backgroundMusic
            };

            audio.clip = _backgroundMusic;
            audio.time = GameManager.music_time;
            audio.Play();
        }
    }
}