using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Vector2")]
public class Vector2Variable : ScriptableObject
{
    public Vector2 value;
    [TextArea] public string description;

    public void SetValue(Vector2 newValue)
    {
        value = newValue;
    }
}