using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Color")]
public class ColorVariable : ScriptableObject
{
    public Color Value;
    [TextArea]
    public string Description;

    public void SetValue(Color value)
    {
        Value = value;
    }
}
