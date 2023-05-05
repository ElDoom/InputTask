using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SilverTrain.ActionEditor
{

    [CreateAssetMenu(menuName = "Action/DontUse-Press Action")]
    public class Press : Action
    {

        public Input[] inputs;
        public int number;
        public KeyCode[] keybind;

        public Press()
        {
            this.ActionType = ActionEnum.FIRE;
        }
        public bool OnPress()
        {
            foreach (KeyCode key in keybind)
            {
                if (Input.GetKeyDown(key))
                    return true;
            }
            return false;
        }

        public override void setName(string name)
        {
            this.name = name;
        }

 
    }

}
