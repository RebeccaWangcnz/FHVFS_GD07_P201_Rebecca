using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSystem : MonoBehaviour
{
    private void OnEnable()
    {
        Evently.Instance.Subscribe<ChangeWallEvent>(ChangeWall);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<ChangeWallEvent>(ChangeWall);
    }
    private void ChangeWall(ChangeWallEvent evt)
    {

    }
}
