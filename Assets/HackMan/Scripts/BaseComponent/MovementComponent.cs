using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseGridObject
{
    public float MoveSpeed;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    protected IntVector2 currentInputDirecion;
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
        if(GridPos==targetGridPosition&&!(GridPos+currentInputDirecion).IsWall())
        {
            targetGridPosition += currentInputDirecion;
            previousInputDirection = currentInputDirecion;
        }
        //if we set a new target and our current input is not valid->is a wall
        else  if(GridPos==targetGridPosition&&! (GridPos + previousInputDirection).IsWall())
        {
            targetGridPosition += previousInputDirection;
        }
        if (GridPos == targetGridPosition) return;
        progressToTarget += MoveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(GridPos.ToVector3(),targetGridPosition.ToVector3(),progressToTarget);//a need to be a constant value
       // Debug.Log("base method...");
    }
}
