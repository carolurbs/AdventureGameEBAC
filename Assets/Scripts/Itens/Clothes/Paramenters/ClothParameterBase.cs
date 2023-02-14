using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothes;

[CreateAssetMenu]
public class ClothParameterBase : ScriptableObject
{
    public ClothType clothType;
    public float duration = 2f;
}
