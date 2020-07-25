using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BoolReference))]
public class BoolReferenceDrawer : PropertyDrawer
{
    private int selected;

    private void OnEnable()
    {
        selected = 0;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) {imagePosition = ImagePosition.ImageOnly};

        var buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        var options = new string[]
        {
            "Var", "Cons"
        };

        selected = EditorGUI.Popup(buttonRect, selected, options, popupStyle);

        if (selected == 0)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("variable"), GUIContent.none);
            property.FindPropertyRelative("useVariable").boolValue = true;
        }
        else
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("constantValue"), GUIContent.none);
            property.FindPropertyRelative("useVariable").boolValue = false;
        }

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}