using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallEvent : MonoBehaviour
{
    public IntVector2 wallPos;
    public ChangeWallEvent(IntVector2 WallPos)
    {
        wallPos = WallPos;
    }
}
