using System;
using UnityEngine;

[Serializable]
public class ColorReference
{
    public bool UseVariable = true;
    public Color ConstantValue;
    public ColorVariable Variable;

    public Color Value
    {
        get { return UseVariable ? Variable.Value : ConstantValue; }
        set { Variable.Value = value; }
    }
   	
}
