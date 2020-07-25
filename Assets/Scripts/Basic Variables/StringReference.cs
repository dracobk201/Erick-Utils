using System;

[Serializable]
public class StringReference
{
    public bool useVariable = true;
    public string constantValue;
    public StringVariable variable;

    public string Value
    {
        get => useVariable ? variable.value : constantValue;
        set => variable.value = value;
    }
}