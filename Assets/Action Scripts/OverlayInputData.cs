using UnityEngine;

namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// Overlay script for the Input editor
    /// </summary>
    public class OverlayInputData : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        bool m_showOverlay = false;

        [SerializeField]
        KeyCode m_keyOverlay = KeyCode.O;

        [SerializeField]
        int m_fontSize = 30;

        [SerializeField]
        Color m_fontColor = Color.black;

        [SerializeField]
        InputActionMove m_inputActionMove = null;

        [SerializeField]
        InputActionPress m_inputActionPress = null;


        string m_textMove = "";
        string m_textPress = "";
        Vector2 m_moveData;
        float m_pressedTime ;
        
        float m_overlayX = 10;
        float m_overlayY = 10;

        #endregion

        #region Main Methods
        void Start()
        {
            m_inputActionPress.OnInputChanged -= PressedButton;
            m_inputActionPress.OnInputChanged += PressedButton;
        }
        private void Update()
        {
            
            if (Input.GetKeyDown(m_keyOverlay))// Toggle the overlay on/off when pressing a key (e.g., F1)
            {
                m_showOverlay = !m_showOverlay;
                Debug.Log("Activate Overlay");
            }

        }

        

        private void OnDisable()
        {
            m_inputActionPress.OnInputChanged -= PressedButton;
        }
        #endregion

        #region Utility Methods
        private void OnGUI()
        {
            if (m_showOverlay)
            {
                // Set the style for the overlay text
                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.fontSize = m_fontSize;
                style.normal.textColor = m_fontColor;

                if (m_inputActionMove != null)
                {
                    m_moveData = m_inputActionMove.OnMove();
                    m_textMove = "Move data: X:" + m_moveData.x + " Y: " + m_moveData.y + "\n";
                }
                if (m_inputActionPress != null)
                {
                    m_textPress = "Button/Key/Input pressed at: " + m_pressedTime + "\n";
                }

                // Set the overlay text
                string overlayText = "Data: \n" + m_textMove + m_textPress;

                // Display the overlay text
                GUI.Label(new Rect(m_overlayX, m_overlayY, Screen.width, Screen.height), overlayText, style);
            }
        }

        public void PressedButton()
        {
            m_pressedTime = Time.time;
        }
        #endregion
    }
}

