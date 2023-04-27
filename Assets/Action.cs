using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract bool OnPress(string name, List<Input> inputs);
}
