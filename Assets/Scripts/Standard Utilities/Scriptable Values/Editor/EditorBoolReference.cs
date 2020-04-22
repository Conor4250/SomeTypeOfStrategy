using UnityEngine;
using UnityEditor;

namespace StandardUtilities.ScriptableValues
{
    [CustomPropertyDrawer(typeof(BoolReference))]
    public class BoolReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            
            var toggleRect = new Rect(position.x, position.y, 10, position.height);
            var propertyRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);

            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            EditorGUI.PropertyField(toggleRect, useConstant, GUIContent.none);

            EditorGUI.PropertyField(propertyRect, property.FindPropertyRelative((useConstant.boolValue) ? "constantValue" : "variable"), GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}