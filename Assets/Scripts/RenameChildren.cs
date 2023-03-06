using UnityEditor;
using UnityEngine;

/// <summary>
///     Utility class to rename batches of children of selected objects
///     with a given prefix and starting index
///     <source>
///         https://answers.unity.com/questions/1141004/rename-all-children-of-selected-object.html
///     </source>
/// </summary>
#if UNITY_EDITOR
public class RenameChildren : EditorWindow
{
    private static readonly Vector2Int size = new(250, 100);
    private string childrenPrefix;
    private int startIndex;

    private void OnGUI()
    {
        childrenPrefix = EditorGUILayout.TextField("Children prefix", childrenPrefix);
        startIndex = EditorGUILayout.IntField("Start index", startIndex);
        if (GUILayout.Button("Rename children"))
        {
            var selectedObjects = Selection.gameObjects;
            for (var objectI = 0; objectI < selectedObjects.Length; objectI++)
            {
                var selectedObjectT = selectedObjects[objectI].transform;
                for (int childI = 0, i = startIndex; childI < selectedObjectT.childCount; childI++)
                    selectedObjectT.GetChild(childI).name = $"{childrenPrefix}{i++}";
            }
        }
    }

    [MenuItem("GameObject/Rename children")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<RenameChildren>();
        window.minSize = size;
        window.maxSize = size;
    }
}
#endif