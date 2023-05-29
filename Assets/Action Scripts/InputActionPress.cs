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
        [Tooltip("Seconds to be determined as valid")]
        [SerializeField]
        private float holdTime = 0.4f;

        [Header("Tap")]
        [SerializeField]
        private bool tap = false;
        [SerializeField]
        private float maxTapTime = 0.5f;

        [Header("Multitap")]
        [SerializeField]
        private bool multiTap = false;
        [SerializeField]
        private int tapCount = 2;
        [SerializeField]
        private float maxTapSpacing = 0.4f;


        private bool buttonPressed = false;
        private float buttonDownTime = 0f;
        private float buttonUpTime = 0f;
        private float buttonPressedTime = 0f;
        private float spacingTime = 0f;
        private bool tapDetected = false;
        private bool started = false;
        private bool performed = false;
        private bool cancelled = false;
        private int tapCounter = 0;
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
                    buttonPressed = true;
                    buttonDownTime = Time.time;
                    if(onKeyDown) return true;
                    if (buttonDownTime- spacingTime > maxTapSpacing) tapCounter = 0;
                    tapCounter++;
                     

                }
                if (Input.GetKey(key))
                {
                    if(onKey) return true;
                    buttonPressedTime = Time.time;
                    if (buttonPressedTime - buttonDownTime >= holdTime && hold && buttonPressed)
                    {
                        buttonPressed = false;
                        return true;
                    }
                }
                if (Input.GetKeyUp(key))
                {
                    if(onKeyUp) return true;
                    buttonUpTime = Time.time;
                    intervalTime = buttonUpTime - buttonDownTime;
                    if (intervalTime <= maxTapTime) validTime = true;

                    if (validTime && buttonPressed && tap)
                    {
                        buttonPressed = false;
                        validTime = false;
                        return true;
                    }
                    if (validTime && buttonPressed && multiTap)
                    {
                        validTime = false;
                        buttonPressed = false;
                        spacingTime = Time.time;
                        if (tapCounter == tapCount)
                        {
                            tapCounter = 0;
                            return true;
                        }
                    }
                }
                //Debug.Log("Counter ="+tapCounter);
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
