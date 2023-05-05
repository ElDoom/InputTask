using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    public class CubeControllerBlue : MonoBehaviour
    {
        [SerializeField]
        private InputActionPress actions;

        //GameObject gameObject;
        // Start is called before the first frame update
        void Start()
        {
            actions.OnInputChanged -= PressedButton;
            actions.OnInputChanged += PressedButton;
        }

        public void PressedButton() 
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.1f, gameObject.transform.position.z);
        }
  

        private void OnDisable()
        {
            actions.OnInputChanged -= PressedButton;
        }
    }
}
