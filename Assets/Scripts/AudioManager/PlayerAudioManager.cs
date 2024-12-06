using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] private AudioSource audioSource;

    [Header("--------Player Audio Setting--------")]
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip attack;

    public static AudioClip DEATH;
    public static AudioClip HIT;
    public static AudioClip ATTACK;

    private void Start()
    {
        DEATH = death;
        HIT = hit;
        ATTACK = attack;
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
