using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// This is the controller for an object that listens to events
    /// </summary>
    public class CubeControllerBlue : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        InputActionPress m_actions = null;

        [SerializeField]
        InputActions m_actionGroup = null;

        const float INCREMENT = 0.01f;
        #endregion

        // Start is called before the first frame update
        #region Main Methods
        void Start()
        {
            if (m_actions != null) 
            { 
            m_actions.OnInputChanged -= PressedButton;
            m_actions.OnInputChanged += PressedButton;
            }

            if (m_actionGroup != null)
            {
                Debug.Log("Suscribed to actiongroup events");
                m_actionGroup.InputChanged -= PressedButton;
                m_actionGroup.InputChanged += PressedButton;
                m_actionGroup.InputMoveChanged -= MoveAction;
                m_actionGroup.InputMoveChanged += MoveAction;
            }
        }

        public void PressedButton() 
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + INCREMENT, gameObject.transform.position.z);
        }

        public void MoveAction(Vector2 data) 
        {
            Debug.Log(data.ToString());
            gameObject.transform.rotation = new Quaternion(data.x * INCREMENT, data.y * INCREMENT, 0,0);
        }
  

        private void OnDisable()
        {
            if (m_actions != null) m_actions.OnInputChanged -= PressedButton;
            if (m_actionGroup != null)
            {
                m_actionGroup.InputChanged -= PressedButton;
                m_actionGroup.InputMoveChanged -= MoveAction;
            }
        }
        #endregion
    }
}
