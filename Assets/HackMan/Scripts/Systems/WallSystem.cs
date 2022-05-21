using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSystem : MonoBehaviour
{
    public Material wallMat;
    public Material fakeWallMat;
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
        var wall = FindWall(evt.wallPos);
        if (wall != null)
        {
            if (wall.GetComponent<Wall>().fake == true)
            {
                wall.GetComponent<Wall>().fake = false;
                wall.GetComponent<MeshRenderer>().material = wallMat;
            }
            else
            {
                wall.GetComponent<Wall>().fake = true;
                wall.GetComponent<MeshRenderer>().material = fakeWallMat;
            }
        }
    }
    private GameObject FindWall(IntVector2 vector2)
    {
        var walls = FindObjectsOfType<Wall>();
        foreach (var wall in walls)
        {
            if (wall.GridPos == vector2)
                return wall.gameObject;
        }
        return null;
    }
}
