using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/String")]
public class StringVariable : ScriptableObject
{
    public string Value;
    [TextArea]
    public string Description;

    public void SetValue(string value)
    {
        Value = value;
    }
}
