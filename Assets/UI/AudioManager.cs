using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Tao bien de luu tru audio source

    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    // Tao bien de luu tru audio clip
    public AudioClip musicAudioClip;
    void Start()
    {
        musicAudioSource.clip = musicAudioClip;
        musicAudioSource.Play();
    }
}
