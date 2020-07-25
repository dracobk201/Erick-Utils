using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Int")]
public class IntVariable : ScriptableObject
{
    public int value;
    [TextArea] public string description;

    public void SetValue(int newValue)
    {
        value = newValue;
    }
}
