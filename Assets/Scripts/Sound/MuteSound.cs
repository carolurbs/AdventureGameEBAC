using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public AudioSource musicPlayer;
    public List<AudioSource> sfx;
    public bool _isMusicMute;
    public bool _isSFXMute;
    public void Awake()
    {
        _isMusicMute = false;
        _isSFXMute = false;
        CheckMusic();
        CheckSFX();
    }
    public void ToggleButtonForMusic()
    {
        _isMusicMute = !_isMusicMute;
        CheckMusic();

    }
    public void ToggleButtonForSFX()
    {
        _isSFXMute = !_isSFXMute;
        CheckSFX();

    }

    public void CheckMusic()
    {
        if (_isMusicMute)
        {
            MusicMute();
        }
        else
        {
            MusicUnmute();
        }
    }
    public void CheckSFX()
    {
        if (_isMusicMute)
        {
            SFXMute();
        }
        else
        {
            SFXUnmute();
        }
    }

    public void MusicMute()
    {
        musicPlayer.enabled = false;
    }
    public void MusicUnmute()
    {
        musicPlayer.enabled = true;

    }
    public void SFXMute()
    {
        sfx.ForEach(i => i.enabled = false);

    }
    public void SFXUnmute()
    {
        sfx.ForEach(i => i.enabled = true);

    }
}


