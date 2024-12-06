using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] private AudioSource audioSource;

    [Header("--------Player Audio Setting--------")]
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip heal;

    public static AudioClip COIN;
    public static AudioClip HEAL;

    private void Start()
    {
        COIN = coin;
        HEAL = heal;
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
