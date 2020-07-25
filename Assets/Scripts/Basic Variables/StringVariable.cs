using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/String")]
public class StringVariable : ScriptableObject
{
    public string value;
    [TextArea] public string description;

    public void SetValue(string newValue)
    {
        value = newValue;
    }
}