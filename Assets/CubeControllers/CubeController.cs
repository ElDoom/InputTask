using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    public class CubeController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        InputActions m_inputActions;

        Vector3 m_movement;

        bool m_colorChange=false;
        #endregion

        #region Main Methods
        void Update()
        {
            if (m_inputActions.OnPress())
            {
                m_colorChange = !m_colorChange;
                ChangeColor();
                Debug.Log("Button/key/input pressed");
            }

            m_movement = m_inputActions.OnMove();
            Vector3 actual = gameObject.transform.position+ Vector3.Scale(m_movement, new Vector3(0.001f,0.001f,0.001f));
            gameObject.transform.position=actual;
        }
        #endregion

        #region Utility Methods
        void ChangeColor() 
        {

            if (m_colorChange) gameObject.GetComponent<Renderer>().material.color = Color.red;
            if (!m_colorChange) gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        }
        #endregion
    }
}
