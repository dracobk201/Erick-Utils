using System;
using UnityEngine;

[Serializable]
public class Vector3Reference
{
    public bool useVariable = true;
    public Vector3 constantValue;
    public Vector3Variable variable;

    public Vector3 Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}