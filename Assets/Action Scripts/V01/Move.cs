using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SilverTrain.ActionEditor
{
    [CreateAssetMenu(menuName = "Action/Move Action")]
    public class Move : Action
    {
        //List<Input> inputs;
        Input[] inputs;
        Vector2 data;
        public Vector2 OnMove()
        {
            data.x = Input.GetAxis("Horizontal");
            data.y = Input.GetAxis("Vertical");
            return data;
        }

        public override void setName(string name)
        {
            this.name = name;
        }
    }

}
