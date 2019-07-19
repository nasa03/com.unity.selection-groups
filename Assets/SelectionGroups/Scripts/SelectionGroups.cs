using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectionGroups : ScriptableObject
{
    public string[] groups = new string[] { "None", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
    static SelectionGroups instance;
    public static SelectionGroups Instance
    {
        get
        {
            if (instance == null)
            {
                var instances = Resources.FindObjectsOfTypeAll<SelectionGroups>();
                if (instances.Length == 0)
                {
                    throw new UnityException("Please create a Selection Groups asset.");
                }
                if (instances.Length > 1)
                {
                    throw new UnityException("There should only be one Selection Groups asset, please delete one.");
                }
                instance = instances[0];
            }
            return instance;
        }
    }
}
