using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingEvent : MonoBehaviour
{
    public LosingEvent()
    {
        Evently.Instance.Publish(new ResultEvent(false));
    }
}
