using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Ebac.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public PostProcessVolume processVolume;
    [SerializeField] public Vignette vignette;
    public float duration = .1f;
    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }
    IEnumerator FlashColorVignette()
        {

        Vignette tmp;
        if (processVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            vignette = tmp;
        }
        ColorParameter c = new ColorParameter();
        float time = 0;
        while(time<duration)
        {
            c.value = Color.Lerp(Color.black, Color.red,time/duration) ;
            time+=Time.deltaTime;
        vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
       
        }
        time = 0;
        while (time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            vignette.color.Override(c);
            yield return new WaitForEndOfFrame();

        }
    }

}
