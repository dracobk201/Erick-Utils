using System;
using UnityEngine;

[Serializable]
public class StringReference
{
    public bool UseVariable = true;
    public string ConstantValue;
    public StringVariable Variable;

    public string Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }

}
