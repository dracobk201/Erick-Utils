using System;
using UnityEngine;

[Serializable]
public class Vector2Reference
{
    public bool useVariable = true;
    public Vector2 constantValue;
    public Vector2Variable variable;

    public Vector2 Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}