using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MusicManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> musicTracks;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySong(0);
    }

    public void PlaySong(int songID)
    {
        audioSource.clip = musicTracks[songID];
        audioSource.Play();
    }
}
