using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List <SFXSetup> sfxSetups;
    public AudioSource musicSource;
    public void PlayMusicByType(MusicType musicType)
    {
      var music= GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }
    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }
    public void PlaSFXByType(SFXType sfxType)
    {
        var sfx = GetMusicByType(sfxType);
        musicSource.clip = sfx.audioClip;
        musicSource.Play();
    }
    public SFXSetup GetMusicByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }
}
public enum SFXType
{
    TYPE01,
    TYPE02,
    TYPE03

}
[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip audioClip; 

}

public enum MusicType
{
    TYPE01,
    TYPE02,
    TYPE03

}
[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;

}