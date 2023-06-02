using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// Window to generate a new Action Press Scriptable Object
    /// It stores the action on "SilverbackResources" folder
    /// </summary>
    public class GenerateActionPress : EditorWindow
    {
        #region Private Variables
        SerializedObject m_serializedObject;

        SerializedProperty m_serializedProperty;

        #endregion

        #region Protected Variables
        protected InputActionPress[] m_inputActionPress;
        #endregion

        #region Public Variables
        public InputActionPress newInputActionPress;
        #endregion

        #region Main Methods
        private void OnGUI()
        {

            m_serializedObject = new SerializedObject(newInputActionPress);
            m_serializedProperty = m_serializedObject.GetIterator();
            m_serializedProperty.NextVisible(true);


            EditorGUILayout.LabelField("Press Action");
            DrawProperties(m_serializedProperty);
            if (GUILayout.Button("save"))
            {
                m_inputActionPress = GetPressInstances<InputActionPress>();

                if (newInputActionPress.ActionName == null) newInputActionPress.ActionName = "ActionPress" + (m_inputActionPress.Length + 1);

                if (!AssetDatabase.IsValidFolder("Assets/SilverbackResources")) AssetDatabase.CreateFolder("Assets", "SilverbackResources");

                AssetDatabase.CreateAsset(newInputActionPress, "Assets/SilverbackResources/ActionPress" + (m_inputActionPress.Length + 1) + ".asset");
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
