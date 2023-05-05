using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor
{
    public class CapsuleExample : MonoBehaviour
    {
      
        [SerializeField]
        CompositeAction action;
        Vector2 mov;
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (action.onPress())
            {
                Debug.Log("Pressed button"+action.GetInstanceID().ToString());
            }

            mov = action.OnMove();
           // Debug.Log("MovX: "+mov.x+" movY: "+mov.y);
        }
    }
}
