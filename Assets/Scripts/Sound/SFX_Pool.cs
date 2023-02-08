using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;


public class SFX_Pool : Singleton<SFX_Pool>
{
    private List<AudioSource> _audioSourceList;
    public int poolSize = 10;
    private int _index=0 ; 
    public void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();
        for(int i=0;i<poolSize; i++)
        {
            CreateAudioSourceItem();
        }
       
    }
    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        _audioSourceList.Add(go.AddComponent<AudioSource>());
    }
    public void Play(SFXType sFXType )
    {
        if (sFXType == SFXType.NONE) return;
        var sfx = SoundManager.Instance.GetSFXByType(sFXType);
        _audioSourceList[_index].clip = sfx.audioClip;
        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;

    }
}
