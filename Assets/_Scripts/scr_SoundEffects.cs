using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundEffects : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> soundEffects;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundID)
    {
        audioSource.clip = soundEffects[soundID];
        audioSource.Play();
    }
}
