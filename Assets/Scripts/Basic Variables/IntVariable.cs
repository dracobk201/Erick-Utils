using UnityEngine;
using UnityEngine.Serialization;

namespace Basic_Variables
{
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
}
