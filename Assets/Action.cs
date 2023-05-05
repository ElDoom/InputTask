using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverTrain.ActionEditor { 
public abstract class Action : ScriptableObject
{
        private ActionEnum m_actionType = ActionEnum.NONE;

        public ActionEnum ActionType { get => m_actionType; set => m_actionType = value; }

        public abstract void setName(string name);
    
}

public enum ActionEnum 
{ 
    NONE =0,
    MOVE,
    LOOK,
    FIRE
}

}
