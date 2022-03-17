using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BaseGridObject : MonoBehaviour
{
    // ALL of our object will inherit from this...our pills, walls, ghosts, and HackMan
    public IntVector2 GridPosition;
    public Vector2Int GripPos;

    private void OnEnable()
    {
        //This essentialy means -> var whatever=new Vector2Int(0,0);
        var whatever = Vector2Int.zero;
        var whateverAlso = new Vector2Int(0, 0);
        var whateverAgain = IntVector2.zero;
    }

}

[Serializable]
//struct : a value type
public struct IntVector2
{
    public int x;
    public int y;
    public static IntVector2 zero => new IntVector2(0, 0);
    public IntVector2(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}
