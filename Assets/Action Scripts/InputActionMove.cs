using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// InputActionMove is a Class that generates a Scriptable Object
    /// designed to follow the Input movement
    /// </summary>
    [CreateAssetMenu(menuName = "Action/InputType/Move")]
    public class InputActionMove : ScriptableObject
    {
        #region Private Variables
        private Vector2 m_data;
        [SerializeField]
        private string m_actionName;

        [Header("Processors")]
        [SerializeField]
        private bool m_InvertX= false;
        [SerializeField]
        private bool m_InvertY = false;
        [SerializeField]
        private bool m_Normalize = false;
        [SerializeField]
        private bool m_Scale = false;
        [SerializeField]
        private bool m_DeadZone = false;

        [Header("Scale Values")]
        [SerializeField]
        private Vector2 m_ScaleFactor = Vector2.one;

        [Header("Dead Zone Values")]
        [SerializeField]
        private Vector2 m_DeadZoneValuesMin = Vector2.zero;
        [SerializeField]
        private Vector2 m_DeadZoneValuesMax = Vector2.one;

        #endregion

        #region Utility Methods
        public Vector2 Data { get => m_data; set => m_data = value; }

        public string ActionName { get => m_actionName; set => m_actionName = value; }
        #endregion

        #region Main Methods
        public Vector2 OnMove()
        {
            m_data.x = Input.GetAxis("Horizontal");
            m_data.y = Input.GetAxis("Vertical");
            if (m_InvertX)
            {
                m_data.x = Input.GetAxis("Horizontal") * -1;
            }
            if (m_InvertY)
            {
                m_data.y = Input.GetAxis("Vertical") * -1;
            }
            if (m_Normalize)
            {
                m_data.Normalize();
            }
            if(m_Scale)
            {
                m_data = Vector2.Scale(m_data, m_ScaleFactor);
            }
            if (m_DeadZone) 
            {
                if (m_data.x < m_DeadZoneValuesMin.x) m_data.x = 0;
                if (m_data.y < m_DeadZoneValuesMin.y) m_data.y = 0;
                if (m_data.x > m_DeadZoneValuesMax.x) m_data.x = 1;
                if (m_data.y > m_DeadZoneValuesMax.y) m_data.y = 1;

            }
            return m_data;
        }
        #endregion
    }
}
