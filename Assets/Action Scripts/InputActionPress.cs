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
        string m_actionName;
        
        [SerializeField]
        KeyCode[] m_keyBinds;
        
        [Header("Processors")]
        [SerializeField]
        bool m_Invert = false;

        [Header("Interactions")]
        [Tooltip("Dafault is On Key Down")]
        [SerializeField]
        bool m_onKey = false;
        
        [SerializeField]
        bool m_onKeyDown = true;
        
        [SerializeField]
        bool m_onKeyUp = false;

        [Header("Hold")]
        [SerializeField]
        bool m_hold = false;
        
        [Tooltip("Seconds to be determined as valid")]
        [SerializeField]
        float m_holdTime = 0.4f;

        [Header("Tap")]
        [SerializeField]
        bool m_tap = false;
        [SerializeField]
        float m_maxTapTime = 0.5f;

        [Header("Multitap")]
        [SerializeField]
        bool m_multiTap = false;
        
        [SerializeField]
        int m_tapCount = 2;
        [SerializeField]
        float m_maxTapSpacing = 0.4f;


        bool m_buttonPressed = false;

        float m_buttonDownTime = 0f;
        
        float m_buttonUpTime = 0f;
        
        float m_buttonPressedTime = 0f;
        
        float m_spacingTime = 0f;
        
        int m_tapCounter = 0;
        
        #endregion

        #region Main Methods
        public bool OnPress()
        {
            bool keyValue = Preprocess();
       
            if (m_Invert && !keyValue)
            { 
                PressEvent();
                return (true);
            }
            if(keyValue) PressEvent();
            return keyValue;
        }
        #endregion

        #region Event Methods
        public delegate void InputChanged();
        
        public event InputChanged OnInputChanged;
        private void PressEvent() => OnInputChanged?.Invoke();
        #endregion

        #region Utility Methods
        public KeyCode[] KeyBinds { get => m_keyBinds; set => m_keyBinds = value; }

        public string ActionName { get => m_actionName; set => m_actionName = value; }

        private bool Preprocess()
        {
            float intervalTime = 0f;
            bool validTime = false;
            foreach (KeyCode key in m_keyBinds)
            {
                if (Input.GetKeyDown(key))
                {
                    m_buttonPressed = true;
                    m_buttonDownTime = Time.time;
                    if(m_onKeyDown) return true;
                    if (m_buttonDownTime- m_spacingTime > m_maxTapSpacing) m_tapCounter = 0;
                    m_tapCounter++;
                     

                }
                if (Input.GetKey(key))
                {
                    if(m_onKey) return true;
                    m_buttonPressedTime = Time.time;
                    if (m_buttonPressedTime - m_buttonDownTime >= m_holdTime && m_hold && m_buttonPressed)
                    {
                        m_buttonPressed = false;
                        return true;
                    }
                }
                if (Input.GetKeyUp(key))
                {
                    if(m_onKeyUp) return true;
                    m_buttonUpTime = Time.time;
                    intervalTime = m_buttonUpTime - m_buttonDownTime;
                    if (intervalTime <= m_maxTapTime) validTime = true;

                    if (validTime && m_buttonPressed && m_tap)
                    {
                        m_buttonPressed = false;
                        validTime = false;
                        return true;
                    }
                    if (validTime && m_buttonPressed && m_multiTap)
                    {
                        validTime = false;
                        m_buttonPressed = false;
                        m_spacingTime = Time.time;
                        if (m_tapCounter == m_tapCount)
                        {
                            m_tapCounter = 0;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

    }
}
