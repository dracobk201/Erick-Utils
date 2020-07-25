using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Color")]
public class ColorVariable : ScriptableObject
{
    public Color value;
    [TextArea] public string description;

    public void SetValue(Color newValue)
    {
        value = newValue;
    }
}
