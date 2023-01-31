using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cinemachine;
public class ScreenShake : Singleton<ScreenShake>
{
    public CinemachineVirtualCamera cinemachine;
    public float shakeTime=.1f;
    private CinemachineBasicMultiChannelPerlin c;
    [Header("Shake Values")]
    public float frequency = 3f;
    public float amplitude = 3f;
    public float time = .3f;
    [NaughtyAttributes.Button]
    public void ShakeCamera()
    {
        Shake(frequency,amplitude,time);
    }
    
    
    public void Shake(float amplitude, float frequency, float time )
    {
        c = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        c.m_AmplitudeGain = amplitude;
      c.m_FrequencyGain= frequency;

        shakeTime = time; 
    }
    protected virtual void Update()
    {
        if(shakeTime>0)
        {
            shakeTime -= Time.deltaTime;
        }
        else 
        {
            c.m_AmplitudeGain = 0;
            c.m_FrequencyGain = 0;

        }
    }
}
