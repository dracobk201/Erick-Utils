using System;

[Serializable]
public class BoolReference
{
    public bool useVariable = true;
    public bool constantValue;
    public BoolVariable variable;

    public bool Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}