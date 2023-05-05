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
        #endregion

        #region Utility Methods
        public Vector2 Data { get => m_data; set => m_data = value; }
        #endregion

        #region Main Methods
        public Vector2 OnMove()
        {
            m_data.x = Input.GetAxis("Horizontal");
            m_data.y = Input.GetAxis("Vertical");
            return m_data;
        }
        #endregion
    }
}
