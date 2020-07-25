using System;
using UnityEngine;

[Serializable]
public class ColorReference
{
    public bool useVariable = true;
    public Color constantValue;
    public ColorVariable variable;

    public Color Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}