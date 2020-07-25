using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Vector3")]
public class Vector3Variable : ScriptableObject
{
    public Vector3 value;
    [TextArea] public string description;

    public void SetValue(Vector3 newValue)
    {
        value = newValue;
    }
}