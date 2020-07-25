using System;

[Serializable]
public class IntReference
{
    public bool useVariable = true;
    public int constantValue;
    public IntVariable variable;

    public int Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}