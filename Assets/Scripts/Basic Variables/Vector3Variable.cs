using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Vector3")]
public class Vector3Variable : ScriptableObject
{
    public Vector3 Value;
    [TextArea]
    public string Description;

    public void SetValue(Vector3 value)
    {
        Value = value;
    }

}
