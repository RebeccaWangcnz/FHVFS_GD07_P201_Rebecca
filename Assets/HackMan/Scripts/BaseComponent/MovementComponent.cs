using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseGridObject
{
    public float MoveSpeed;
    [HideInInspector]
    public IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    [HideInInspector]
    public IntVector2 currentInputDirecion;
    private IntVector2 previousInputDirection;
    private void Start()
    {      
        targetGridPosition = GridPos;
    }
    //virtul---> can be overrided
    protected virtual void Update()
    {
        //if we've arrived
        if (transform.position == targetGridPosition.ToVector3())
        {
            progressToTarget = 0f;
            GridPos = targetGridPosition;
        }
        //if we set anew target and our current unput is valid -> not a wall
        if(GridPos==targetGridPosition&& CanGoThrough(GridPos + currentInputDirecion))
        {
            targetGridPosition += currentInputDirecion;
            previousInputDirection = currentInputDirecion;
        }
        //if we set a new target and our current input is not valid->is a wall
        else  if(GridPos==targetGridPosition&&CanGoThrough(GridPos + previousInputDirection))
        {
            targetGridPosition += previousInputDirection;
        }
        if (GridPos == targetGridPosition) return;
        progressToTarget += MoveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(GridPos.ToVector3(),targetGridPosition.ToVector3(),progressToTarget);//a need to be a constant value
       // Debug.Log("base method...");
    }
    protected bool CanGoThrough(IntVector2 vector2)
    {
        var wall = FindWall(vector2);
        return (!vector2.IsWall()&&!vector2.IsEdge())||
            (vector2.IsWall()&& wall != null&& wall.GetComponent<Wall>().fake==true);
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
