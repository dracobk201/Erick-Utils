using System;

[Serializable]
public class FloatReference
{
    public bool useVariable = true;
    public float constantValue;
    public FloatVariable variable;

    public float Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}