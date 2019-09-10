using System;
using UnityEngine;

[Serializable]
public class Vector3Reference
{
    public bool UseVariable = true;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;

    public Vector3 Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }
   	
}
