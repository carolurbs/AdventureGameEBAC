using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public MusicType musicType;
    public AudioSource audioSource;
    private MusicSetup _currentMusicSetup;
    private void Start()
    {
        Play();
    }

    private void Play()
    {
        SoundManager. Instance.GetMusicByType(musicType);
        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Play();
    }
}
