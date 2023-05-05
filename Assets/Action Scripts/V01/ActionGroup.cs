using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SilverTrain.ActionEditor
{
    [CreateAssetMenu(menuName = "Action/DontUse-Action Group")]
    public class ActionGroup : Action
    {
        public Move[] moveActions = null;
        public Press[] pressActions = null;
        public bool abuttonPressed = false;
        private Vector2 data;

        public static ActionGroup actionGroup;

        public void Awake()
        {
            actionGroup = this;
        }

        public delegate void OnInputChange();
        public void OnInputChanged() 
        {
            //OnInputChange?.Invoke();
        }

        public override void setName(string name) => this.name = name;
    }
}