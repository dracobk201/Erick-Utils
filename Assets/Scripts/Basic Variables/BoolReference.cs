using System;
using UnityEngine;

[Serializable]
public class BoolReference
{
    public bool UseVariable = true;
    public bool ConstantValue;
    public BoolVariable Variable;

    public bool Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }

}
