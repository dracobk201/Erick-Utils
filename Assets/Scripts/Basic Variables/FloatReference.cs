using System;
using UnityEngine;

[Serializable]
public class FloatReference
{
    public bool UseVariable = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }
   	
}
