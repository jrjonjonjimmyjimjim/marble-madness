using UnityEngine;

namespace GameLogic
{
    public class PlayMusic : MonoBehaviour
    {
        private AudioSource _audio;
        private AudioClip _backgroundMusic;

        // Start is called before the first frame update
        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _backgroundMusic = GameModeManager.GameMode switch
            {
                GameMode.Tutorial => (AudioClip)Resources.Load("Sounds/Background/Tutorial"),
                GameMode.Level => (AudioClip)Resources.Load("Sounds/Background/Level"),
                GameMode.Time => (AudioClip)Resources.Load("Sounds/Background/Time Attack"),
                GameMode.Survival => (AudioClip)Resources.Load("Sounds/Background/Survival"),
                _ => _backgroundMusic
            };

            _audio.clip = _backgroundMusic;
            _audio.Play();
        }
    }
}