using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Float")]
public class FloatVariable : ScriptableObject
{
    public float Value;
    [TextArea]
    public string Description;

    public void SetValue(float value)
    {
        Value = value;
    }
}
