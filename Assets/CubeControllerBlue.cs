using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    public class CubeControllerBlue : MonoBehaviour
    {
        [SerializeField]
        private InputActionPress actions;

        [SerializeField]
        private const float INCREMENT = 0.001f;

        //GameObject gameObject;
        // Start is called before the first frame update
        void Start()
        {
            actions.OnInputChanged -= PressedButton;
            actions.OnInputChanged += PressedButton;
        }

        public void PressedButton() 
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + INCREMENT, gameObject.transform.position.z);
        }
  

        private void OnDisable()
        {
            actions.OnInputChanged -= PressedButton;
        }
    }
}
