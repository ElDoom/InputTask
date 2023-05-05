using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// InputActions class generates ScriptableObjects that handle move and press 
    /// actions, can be attached to any object to 
    /// </summary>
    [CreateAssetMenu(menuName = "Action/Input Action Group")]
    public class InputActions : ScriptableObject
    {
        #region Private Variables
        [SerializeField]
        private string m_actionName;
        
        [SerializeField]
        private InputActionPress[] m_pressActions;

        [SerializeField]
        private InputActionMove[] m_moveActions;

        private Vector2 data;
        #endregion

        #region Event Methods
        public delegate void onInputChanged();

        public event onInputChanged InputChanged;

        private void PressEvent() => InputChanged?.Invoke();
        #endregion

        #region Utility Methods
        public string ActionName { get => m_actionName; set => m_actionName = value; }

        public InputActionPress[] PressActions { get => m_pressActions; set => m_pressActions = value; }

        public InputActionMove[] MoveActions { get => m_moveActions; set => m_moveActions = value; }
        #endregion

        #region Main Methods
        public bool OnPress()
        {
            foreach (InputActionPress p in m_pressActions)
            {
                if (p.OnPress())
                {
                    PressEvent();
                    return true;
                }
            }
            return false;
        }

       

        public Vector2 OnMove()
        {
            foreach (InputActionMove m in m_moveActions)
            {
                //m_onAction.Invoke();
                data = m.OnMove();
            }
            return data;
        }
        #endregion
    }
}
