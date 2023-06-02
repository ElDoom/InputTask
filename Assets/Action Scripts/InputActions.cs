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
        string m_actionName;
        
        [SerializeField]
        InputActionPress[] m_pressActions;

        [SerializeField]
        InputActionMove[] m_moveActions;

        Vector2 data = Vector2.zero;
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
                data = m.OnMove(); 
            }
            //MoveEvent();
            return data; 
        }
        #endregion

        #region Event Methods
        public delegate void onInputChanged();

        public event onInputChanged InputChanged;

        public delegate void onInputMove(Vector2 data);

        public event onInputMove InputMoveChanged;

        private void PressEvent() => InputChanged?.Invoke();
        private void MoveEvent() => InputMoveChanged(data);
        #endregion

        #region Utility Methods
        public string ActionName { get => m_actionName; set => m_actionName = value; }

        public InputActionPress[] PressActions { get => m_pressActions; set => m_pressActions = value; }

        public InputActionMove[] MoveActions { get => m_moveActions; set => m_moveActions = value; }
        #endregion


    }
}
