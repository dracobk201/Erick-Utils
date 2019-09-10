using System;
using UnityEngine;

[Serializable]
public class IntReference
{
    public bool UseVariable = true;
    public int ConstantValue;
    public IntVariable Variable;

    public int Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }

}
