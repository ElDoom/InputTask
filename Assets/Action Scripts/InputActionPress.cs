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
        private KeyCode[] m_keyBinds;
        #endregion

        #region Event Methods
        public delegate void InputChanged();
        
        public event InputChanged OnInputChanged;
        private void PressEvent() => OnInputChanged?.Invoke();
        #endregion

        #region Utility Methods
        public KeyCode[] KeyBinds { get => m_keyBinds; set => m_keyBinds = value; }
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
