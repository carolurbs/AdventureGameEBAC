using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuteSound : MonoBehaviour
{
    public AudioSource musicPlayer;
    public List<AudioSource> sfx;
    public List<Image> soundOn;
    public List<Image> soundOff;
    public List<Image> musicOn;
    public List<Image> musicOff;
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
        musicOff.ForEach(i => i.enabled = false);
        musicOn.ForEach(i => i.enabled = true);
    }
    public void MusicUnmute()
    {
        musicPlayer.enabled = true;
        musicOff.ForEach(i => i.enabled = true);
        musicOn.ForEach(i => i.enabled = false);
    }
    public void SFXMute()
    {
        sfx.ForEach(i => i.enabled = false);
        soundOff.ForEach(i => i.enabled=false);
        soundOn.ForEach(i => i.enabled = true);

    }
    public void SFXUnmute()
    {
        sfx.ForEach(i => i.enabled = true);
        soundOff.ForEach(i => i.enabled = true);
        soundOn.ForEach(i => i.enabled = false);
    }
}


