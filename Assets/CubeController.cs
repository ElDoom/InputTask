using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField]
        InputActions m_inputActions;

        private Vector3 m_movement;

        // Update is called once per frame
        void Update()
        {
            if (m_inputActions.OnPress())
            {
                Debug.Log("Button Pressed"+ m_inputActions.OnPress().ToString());
            }

            m_movement = m_inputActions.OnMove();
            Vector3 actual = gameObject.transform.position+ m_movement;
            gameObject.transform.position=actual ;
        }
    }
}
