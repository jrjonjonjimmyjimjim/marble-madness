using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Utility
{
    /// <summary>
    ///     Utility class to rename batches of children of selected objects
    ///     with a given prefix and starting index
    ///     <source>
    ///         https://answers.unity.com/questions/1141004/rename-all-children-of-selected-object.html
    ///     </source>
    /// </summary>
    public class RenameChildren : EditorWindow
    {
        private static readonly Vector2Int Size = new(250, 100);
        private string _childrenPrefix;
        private int _startIndex;

        private void OnGUI()
        {
            _childrenPrefix = EditorGUILayout.TextField("Children prefix", _childrenPrefix);
            _startIndex = EditorGUILayout.IntField("Start index", _startIndex);
            if (GUILayout.Button("Rename children"))
            {
                var selectedObjects = Selection.gameObjects;
                foreach (var t in selectedObjects)
                {
                    var selectedObjectT = t.transform;
                    for (int childI = 0, i = _startIndex; childI < selectedObjectT.childCount; childI++)
                        selectedObjectT.GetChild(childI).name = $"{_childrenPrefix}{i++}";
                }
            }
        }

        [MenuItem("GameObject/Rename children")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow<RenameChildren>();
            window.minSize = Size;
            window.maxSize = Size;
        }
    }
}
#endif