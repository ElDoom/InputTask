using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SilverTrain.ActionEditor
{
    public class GenerateActionGroup : EditorWindow
    {
        private SerializedObject serializedObject;
        private SerializedProperty serializedProperty;

        protected InputActions[] inputActions;
        public InputActions newInputAction;

        private void OnGUI()
        {

            serializedObject = new SerializedObject(newInputAction);
            serializedProperty = serializedObject.GetIterator();
            serializedProperty.NextVisible(true);
            DrawProperties(serializedProperty);
            if (GUILayout.Button("save"))
            {
                inputActions = GetActionInstances<InputActions>();
                
                if (newInputAction.ActionName == null) newInputAction.ActionName = "ActionGroup" + (inputActions.Length + 1);
                
                if (!AssetDatabase.IsValidFolder("Assets/SilverbackResources")) AssetDatabase.CreateFolder("Assets", "SilverbackResources");
                
                AssetDatabase.CreateAsset(newInputAction, "Assets/SilverbackResources/ActionGroup" + (inputActions.Length + 1) + ".asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Close();
            }

            Apply();
        }

        protected void DrawProperties(SerializedProperty p)
        {

            while (p.NextVisible(false))
            {
                EditorGUILayout.PropertyField(p, true);

            }
        }


        public static T[] GetActionInstances<T>() where T : InputActions
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }
            return a;
        }

        public static T[] GetMoveInstances<T>() where T : InputActionMove
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }
            return a;
        }

        public static T[] GetPressInstances<T>() where T : InputActionPress
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }
            return a;
        }

        protected void Apply()
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}

