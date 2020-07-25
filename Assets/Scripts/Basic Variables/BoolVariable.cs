using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Bool")]
public class BoolVariable : ScriptableObject
{
    public bool value;
    [TextArea] public string description;

    public void SetValue(bool newValue)
    {
        value = newValue;
    }
}