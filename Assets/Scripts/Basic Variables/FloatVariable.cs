using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Float")]
public class FloatVariable : ScriptableObject
{
    public float value;
    [TextArea] public string description;

    public void SetValue(float newValue)
    {
        value = newValue;
    }
}