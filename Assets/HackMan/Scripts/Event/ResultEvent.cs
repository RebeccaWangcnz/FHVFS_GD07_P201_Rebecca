using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultEvent : MonoBehaviour
{
    public bool winOrLose;
    public ResultEvent(bool boo)
    {
        winOrLose = boo;
    }
}
