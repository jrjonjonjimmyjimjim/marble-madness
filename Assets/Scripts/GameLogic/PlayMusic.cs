using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioClip backgroundMusic;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        if (GameManager.gameMode == GameMode.Tutorial)
        {
            backgroundMusic = (AudioClip)Resources.Load("Sounds/Background/Tutorial");
        }
        else if (GameManager.gameMode == GameMode.Level)
        {
            backgroundMusic = (AudioClip)Resources.Load("Sounds/Background/Level");
        }
        else if (GameManager.gameMode == GameMode.Time)
        {
            backgroundMusic = (AudioClip)Resources.Load("Sounds/Background/Time Attack");
        }
        else if (GameManager.gameMode == GameMode.Survival)
        {
            backgroundMusic = (AudioClip)Resources.Load("Sounds/Background/Survival");
        }
        _audio.clip = backgroundMusic;
        _audio.Play();
    }

}
