using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] private AudioSource audioSource;

    [Header("--------Player Audio Setting--------")]
    [SerializeField] private AudioClip background;

    private void Start()
    {
        audioSource.clip = background;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        
    }

    private void PlayBackGround()
    {
        audioSource.clip = background;
        audioSource.loop = true;
        audioSource.Play();
    }
}
