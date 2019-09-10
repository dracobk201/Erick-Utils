using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Int")]
public class IntVariable : ScriptableObject
{
    public int Value;
    [TextArea]
    public string Description;

    public void SetValue(int value)
    {
        Value = value;
    }
}
