using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MovementComponent
{
    private bool hasDirection;
    private IntVector2[] movementDirections = new IntVector2[]
    {
        IntVector2.up,
        IntVector2.down,
        IntVector2.left,
        IntVector2.right,
    };
    public IntVector2 direction;

    public Material wallMat;
    public Material fakeWallMat;
    private void Awake()
    {
        hasDirection = false;
    }
    protected override void Update()
    {
        if(!hasDirection)
        {
            //Debug.Log((transform.position.ToIntVector2() + direction).ToVector3());
            if (direction != IntVector2.zero && !(transform.position.ToIntVector2() + direction).IsWall())
                currentInputDirecion = direction;
            else
                Destroy(this.gameObject);
            hasDirection = true;
        }
        if((GridPos + currentInputDirecion).IsWall())
        {
            var wall = FindWall(GridPos + currentInputDirecion);
            if(wall!=null)
            {
                if(wall.GetComponent<Wall>().fake == true)
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
            Destroy(this.gameObject);
        }
        base.Update();
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
