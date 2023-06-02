using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// Window to generate a new Action Group
    /// It stores the action on "SilverbackResources" folder
    /// </summary>
    public class GenerateActionGroup : EditorWindow
    {
        #region Private Variables
        SerializedObject m_serializedObject;
        
        SerializedProperty m_serializedProperty;
        #endregion

        #region Protected Variables
        protected InputActions[] m_inputActions;
        #endregion

        #region Public Variables
        public InputActions newInputAction;
        #endregion

        #region Main Methods
        private void OnGUI()
        {

            m_serializedObject = new SerializedObject(newInputAction);
            m_serializedProperty = m_serializedObject.GetIterator();
            m_serializedProperty.NextVisible(true);
            DrawProperties(m_serializedProperty);
            if (GUILayout.Button("save"))
            {
                m_inputActions = GetActionInstances<InputActions>();
                
                if (newInputAction.ActionName == null) newInputAction.ActionName = "ActionGroup" + (m_inputActions.Length + 1);
                
                if (!AssetDatabase.IsValidFolder("Assets/SilverbackResources")) AssetDatabase.CreateFolder("Assets", "SilverbackResources");
                
                AssetDatabase.CreateAsset(newInputAction, "Assets/SilverbackResources/ActionGroup" + (m_inputActions.Length + 1) + ".asset");
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

        protected void Apply() => m_serializedObject.ApplyModifiedProperties();
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

