using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningEvent : MonoBehaviour
{
    public WinningEvent()
    {
        Evently.Instance.Publish(new ResultEvent(true));
    }
}
