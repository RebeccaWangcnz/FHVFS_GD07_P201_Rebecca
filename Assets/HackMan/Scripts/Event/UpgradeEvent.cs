using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEvent : MonoBehaviour
{
    public IntVector2 position;
    public Pill[] blankPos;
    public UpgradeEvent(IntVector2 pos,Pill[] blank)
    {
        position = pos;
        blankPos = blank;
    }
}
