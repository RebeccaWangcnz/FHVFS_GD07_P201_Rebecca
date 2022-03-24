using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackman : BaseGridMovement
{
    protected override void Update()
    {
        // base.Update();
        //Debug.Log("overriding method")
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirecion = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirecion = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirecion = new IntVector2(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirecion = new IntVector2(0, 1);
        }
        Debug.Log($"x:{currentInputDirecion.x}|y:{currentInputDirecion.y}");
    }
}
