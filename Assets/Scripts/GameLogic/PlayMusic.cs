using UnityEngine;

namespace GameLogic
{
    public class PlayMusic : MonoBehaviour
    {
        public static PlayMusic Instance;
        public static AudioSource audio;
        private AudioClip _backgroundMusic;

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
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