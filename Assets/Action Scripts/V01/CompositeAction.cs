using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

namespace SilverTrain.ActionEditor
{
    [CreateAssetMenu(menuName = "Action/Group of Inputs")]
    public class CompositeAction : Action
    {

        public Move[] moveActions=null;
        public Press[] pressActions=null;
        public bool abuttonPressed = false;
        private Vector2 data;
        UnityEvent m_onAction;

        public delegate void updated();
        //public static event updated OnInputChanged;

        public override void setName(string name) => this.name = name;

      //  public CompositeAction() => m_onAction.AddListener(MyAction);

        public bool onPress() 
        {
            foreach (Press p in pressActions)
            {
                if (p.OnPress()) 
                {
                    m_onAction.Invoke();
                    return true;
                }
            }
            return false;
        }

        public Vector2 OnMove()
        {
            foreach (Move m in moveActions)
            {
                m_onAction.Invoke();
                data = m.OnMove();
            }
            return data;
        }

        void MyAction()
        {
            //Output message to the console
            Debug.Log("Do Stuff");
        }
    }

}