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


    private void Awake()
    {
        hasDirection = false;
    }
    protected override void Update()
    {
        if(!hasDirection)
        {
            currentInputDirecion = direction;
            hasDirection = true;
        }
        if ((GridPos + currentInputDirecion).IsWall())
        {
            Evently.Instance.Publish(new ChangeWallEvent(GridPos + currentInputDirecion));
            Destroy(this.gameObject);
        }
        if (!CanGoThrough(GridPos + currentInputDirecion))
        {
            Destroy(this.gameObject);
        }

        base.Update();
    }
}
