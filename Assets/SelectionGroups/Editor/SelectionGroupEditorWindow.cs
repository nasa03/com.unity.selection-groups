using System;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class SelectionGroupEditorWindow : EditorWindow
{

    [MenuItem("Window/Selection Groups")]
    static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<SelectionGroupEditorWindow>();

        window.titleContent.text = "Selection Groups";
        window.ShowUtility();
    }

    void OnGUI()
    {
        for (var i = 0; i < SelectionGroups.Instance.groups.Length; i++)
        {
            var groupName = SelectionGroups.Instance.groups[i];
            if (string.IsNullOrEmpty(groupName)) continue;
            var ev = Event.current;
            if (ev.shift)
            {
                if (GUILayout.Button($"{groupName} +"))
                {
                    foreach (var g in Selection.gameObjects)
                    {
                        var sg = g.GetComponent<SelectionGroup>();
                        if (sg == null) sg = g.AddComponent<SelectionGroup>();
                        sg.groupMask |= (1 << i);
                    }
                }
            }
            else if (ev.alt)
            {
                if (GUILayout.Button($"{groupName} -"))
                {
                }
            }
            else
            {
                if (GUILayout.Button(groupName))
                {
                    Selection.objects = (from sg in SelectionGroup.instances where (sg.groupMask & (1 << i)) != 0 select sg.gameObject).ToArray();
                }
            }

        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.HelpBox("Hold shift to add, alt to remove.", MessageType.Info);
        Repaint();
    }

}
