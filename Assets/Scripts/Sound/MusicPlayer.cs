using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        Play();
    }

    private void Play()
    {
        audioSource.Play();
    }
}
