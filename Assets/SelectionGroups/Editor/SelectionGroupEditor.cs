using System;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SelectionGroup))]
public class SelectionGroupEditor : Editor
{
    StringBuilder stringBuilder = new StringBuilder();
    public override void OnInspectorGUI()
    {
        var property = serializedObject.FindProperty("groupMask");
        var menu = new GenericMenu();
        for (int i = 0; i < SelectionGroups.Instance.groups.Length; i++)
        {
            var groupName = SelectionGroups.Instance.groups[i];
            if (string.IsNullOrEmpty(groupName))
                continue;
            var on = (property.intValue & (1 << i)) != 0;
            menu.AddItem(new GUIContent(groupName), on, ToggleBit, i);
            if (on)
            {
                if (stringBuilder.Length > 0) stringBuilder.Append(", ");
                stringBuilder.Append(groupName);
            }
        }
        var buttonText = stringBuilder.ToString();
        stringBuilder.Clear();
        if (EditorGUILayout.DropdownButton(new GUIContent($"Groups: {buttonText}"), FocusType.Passive))
        {
            menu.ShowAsContext();
        }
    }

    void ToggleBit(object data)
    {
        var bit = (int)data;
        var property = serializedObject.FindProperty("groupMask");
        property.intValue ^= (1 << bit);
        serializedObject.ApplyModifiedProperties();
    }
}
