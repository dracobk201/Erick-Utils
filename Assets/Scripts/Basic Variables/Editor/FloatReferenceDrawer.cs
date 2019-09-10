using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{
    private int selected;

    private void OnEnable()
    {
        selected = 0;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        GUIStyle popupStyle;
        popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
        popupStyle.imagePosition = ImagePosition.ImageOnly;

        // Calculate rect for configuration button
        Rect buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        // Draw fields - passs GUIContent.none to each so they are drawn without labels


        string[] options = new string[]
        {
            "Var", "Cons"
        };

        selected = EditorGUI.Popup(buttonRect, selected, options, popupStyle);

        if (selected == 0)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("Variable"), GUIContent.none);
            property.FindPropertyRelative("UseVariable").boolValue = true;
        }
        else
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("ConstantValue"), GUIContent.none);
            property.FindPropertyRelative("UseVariable").boolValue = false;
        }

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
