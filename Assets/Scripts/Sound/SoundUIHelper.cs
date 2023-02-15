using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIHelper : MonoBehaviour
{
    public AudioSource button;




    public void PlaySFX()
    {
        if (button == null) button.Play();
    }
}