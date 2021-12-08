using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundEffects : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> soundEffects;

    private AudioSource audioSource;

    public enum SFX
    {
        StepNormal = 0,
        StepSoft
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PlaySound(SFX soundID)
    {
        audioSource.clip = soundEffects[(int)soundID];
        audioSource.Play();
    }
}
