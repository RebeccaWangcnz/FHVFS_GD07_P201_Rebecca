using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    //Extension methods allow us to EXTEND the functionality of our class
    //This follows one of our principles, that classes should be CLOSED  to modified
    //this+type+name
    public static Vector3 ToVector3(this IntVector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }
    public static IntVector2 ToIntVector2(this Vector3 vector3)
    {
        return new IntVector2((int)vector3.x, (int)vector3.y);
    }
    public static bool IsWall(this IntVector2 vector2)
    {

        return LevelGeneratorSystem.Grid[Mathf.Abs(vector2.y), vector2.x] == 1;
    }
    public static bool IsEdge(this IntVector2 vector2)
    {

        return LevelGeneratorSystem.Grid[Mathf.Abs(vector2.y), vector2.x] == 4;
    }
    public static bool IsPill(this IntVector2 vector2)
    {
        return LevelGeneratorSystem.Grid[Mathf.Abs(vector2.y), vector2.x] == 0;
    }
}
