using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackman : BaseGridMovement
{
    protected override void Update()
    {
        //Debug.Log("overriding method")
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirecion = IntVector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirecion =IntVector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirecion =IntVector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirecion =IntVector2.up;
        }

        Debug.Log($"x:{currentInputDirecion.x}|y:{currentInputDirecion.y}");
        base.Update();
        //transform.position = progressToTarget * currentInputDirecion;
    }
}
