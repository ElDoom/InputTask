using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// Generates a Window to Edit the actions
    /// </summary>
    public class EditorWindowActions : EditorWindow
    {
        #region Protected Variables
        protected SerializedObject m_serializedObject;

        protected SerializedProperty m_serializedProperty;
        
        protected InputActions[] actionsToEdit;
        
        protected string selectedPropertyPach;
        
        protected string selectedProperty;
        #endregion

        #region Main Methods
        [MenuItem("Tool/Input Editor")]
        protected static void ShowWindow()
        {
            EditorWindowActions window = GetWindow<EditorWindowActions>();
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Images/settings.png");
            window.titleContent = new GUIContent("Input Action Editor", icon); //, icon
            window.minSize = new Vector2(600, 300);
        }

        private void OnGUI()
        {
            actionsToEdit = GetActionInstances<InputActions>();
            m_serializedObject = new SerializedObject(actionsToEdit[0]);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

            EditorGUILayout.LabelField("Actions");

            DrawSliderBar(actionsToEdit);

            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

            EditorGUILayout.LabelField("Properties");

            if (selectedProperty != null)
            {
                for (int i = 0; i < actionsToEdit.Length; i++)
                {
                    if (actionsToEdit[i].ActionName == selectedProperty)
                    {
                        m_serializedObject = new SerializedObject(actionsToEdit[i]);
                        m_serializedProperty = m_serializedObject.GetIterator();
                        m_serializedProperty.NextVisible(true);
                        DrawProperties(m_serializedProperty);
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("Select an item from the list");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

            EditorGUILayout.LabelField("TODO...");

            EditorGUILayout.LabelField("Processors...");

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();


            Apply();
        }

        protected void DrawProperties(SerializedProperty p)
        {

            while (p.NextVisible(false))
            {
                EditorGUILayout.PropertyField(p, true);

            }


        }


        protected void DrawSliderBar(InputActions[] prop)
        {
            foreach (InputActions p in prop)
            {
                if (GUILayout.Button(p.ActionName))
                {
                    selectedPropertyPach = p.ActionName;
                }
            }

            if (!string.IsNullOrEmpty(selectedPropertyPach))
            {
                selectedProperty = selectedPropertyPach;
            }

            if (GUILayout.Button("New Group of Actions"))
            {
                InputActions newActions = ScriptableObject.CreateInstance<InputActions>();
                GenerateActionGroup newActionWindow = GetWindow<GenerateActionGroup>("New Group");
                newActionWindow.newInputAction = newActions;

            }
        }

        protected void Apply()
        {
            m_serializedObject.ApplyModifiedProperties();
        }
        #endregion

        #region Utility Methods
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
        #endregion

    }
}
