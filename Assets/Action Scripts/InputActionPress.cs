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
        private bool m_Invert = false;
        [Tooltip("TODO: ")]
        [SerializeField]
        private bool m_AxisDeadZone = false;
        [SerializeField]
        private bool m_Clamp = false;
        
        
        [Tooltip("To call you need to use the OnPressValue")]
        [SerializeField]
        private bool m_Scale = false;
        [SerializeField]
        private bool m_Normalize = false;



        [Header("Dead Zone Values")]
        [Tooltip("TODO: ")]
        [SerializeField]
        private Vector2 m_DeadZoneValuesMin = Vector2.zero;
        [SerializeField]
        private Vector2 m_DeadZoneValuesMax = Vector2.one;

        [Header("Clamp Values")]
        [Tooltip("TODO: ")] //Set the input values under min to min and over max to max
        [SerializeField]
        private float m_ClampMin = 0;
        [SerializeField]
        private float m_ClampMax = 0;

        [Header("Interactions")]
        [Header("Trigger Behaviour")]
        [Tooltip("Dafault is On Key Down")]
        [SerializeField]
        private bool onKey = false;
        [SerializeField]
        private bool onKeyDown = true;
        [SerializeField]
        private bool onKeyUp = false;

        [Header("Hold")]
        [SerializeField]
        private bool hold = false;
        [SerializeField]
        private float holdTime = 0.1f;

        [Header("Tap")]
        [SerializeField]
        private bool tap = false;
        [SerializeField]
        private float minTapTime = 0.5f;

        [Header("Multitap")]
        [SerializeField]
        private bool multiTap = false;
        [SerializeField]
        private int tapCount = 2;
        [SerializeField]
        private float maxTapSpacing = 0.4f;

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
            foreach (KeyCode key in m_keyBinds)
            {
                if (Input.GetKeyDown(key) && onKeyDown)
                {
                    //PressEvent();
                    return true;
                }
                if (Input.GetKey(key) && onKey)
                {
                    //PressEvent();
                    return true;
                }
                if (Input.GetKeyUp(key) && onKeyUp)
                {
                    //PressEvent();
                    return true;
                }

            }
            return false;
        }
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

    }
}
