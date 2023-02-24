using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIUpdater : MonoBehaviour
{

    public Image uiImage;
    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.Linear;
    private Tween _currTween;

    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;

    }
    public void UpdateValue(float max, float current)
    {
        if (_currTween != null) _currTween.Kill();
        uiImage.DOFillAmount(1 - (current / max), duration).SetEase(ease);
    }
}
