using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// InputActionPress is a Class that generates a Scriptable Object
    /// designed to follow the a group of input actions assigned to it
    /// </summary>
    [CreateAssetMenu(menuName = "Action/InputType/Press")]
    public class InputActionPress : ScriptableObject
    {
        #region Private Variables
        [SerializeField]
        private string m_actionName;
        [SerializeField]
        private KeyCode[] m_keyBinds;
        


        [Header("Processors")]
        [SerializeField]
        private bool m_AxisDeadZone = false;
        [SerializeField]
        private bool m_Clamp = false;
        [SerializeField]
        private bool m_Invert = false;
        [SerializeField]
        private bool m_Normalize = false;
        [SerializeField]
        private bool m_Scale = false;

        

        [Header("Dead Zone Values")]
        [SerializeField]
        private Vector2 m_DeadZoneValuesMin = Vector2.zero;
        [SerializeField]
        private Vector2 m_DeadZoneValuesMax = Vector2.one;

        [Header("Clamp Values")]
        [Tooltip("Set the input values under min to min and over max to max")]
        [SerializeField]
        private float m_ClampMin = 0;
        [SerializeField]
        private float m_ClampMax = 0;
        #endregion

        #region Event Methods
        public delegate void InputChanged();
        
        public event InputChanged OnInputChanged;
        private void PressEvent() => OnInputChanged?.Invoke();
        #endregion

        #region Utility Methods
        public KeyCode[] KeyBinds { get => m_keyBinds; set => m_keyBinds = value; }

        public string ActionName { get => m_actionName; set => m_actionName = value; }
        #endregion

        #region Main Methods
        public bool OnPress()
        {
            foreach (KeyCode key in m_keyBinds)
            {
                if (Input.GetKeyDown(key))
                {
                    PressEvent();
                    return true; 
                }
                    
            }
            return false;
        }
        #endregion

    }
}
