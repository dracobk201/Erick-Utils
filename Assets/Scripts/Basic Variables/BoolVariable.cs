using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Bool")]
public class BoolVariable : ScriptableObject
{
    public bool Value;
    [TextArea]
    public string Description;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
