using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SelectionGroup : MonoBehaviour
{
    public static HashSet<SelectionGroup> instances = new HashSet<SelectionGroup>();

    public int groupMask;

    void OnEnable() => instances.Add(this);
    void OnDisable() => instances.Remove(this);
}
