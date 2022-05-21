using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEvent : MonoBehaviour
{
    public IntVector2 direction;
    public IntVector2 instantiatePos;
    public ShootingEvent(IntVector2 dir, IntVector2 pos)
    {
        direction = dir;
        instantiatePos = pos;
    }
}
