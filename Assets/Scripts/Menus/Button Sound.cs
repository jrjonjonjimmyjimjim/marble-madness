using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioSource _audio;
    private AudioClip _audioClip;
    // Start is called before the first frame update
    void Start()
    {
        _audioClip = (AudioClip)Resources.Load("Sounds/SFX/UI3");
        _audio = new AudioSource();
    }

    void Play()
    {
        _audio.PlayOneShot(_audioClip);
    }
}
