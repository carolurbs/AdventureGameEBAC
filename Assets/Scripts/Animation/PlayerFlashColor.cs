using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFlashColor : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    [Header("Setup")]
    public Color color = Color.red;
    public float duration = .1f;

    private Color defaultColor;
    private Tween _currTween;
    private void OnValidate()
    {
        if (skinnedMeshRenderer == null) skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    private void Start()
    {
        defaultColor = skinnedMeshRenderer.material.GetColor("_EmissionColor");

    }
    [NaughtyAttributes.Button]
    public void Flash()
    {
        if (skinnedMeshRenderer != null && !_currTween.IsActive())
            _currTween = skinnedMeshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
