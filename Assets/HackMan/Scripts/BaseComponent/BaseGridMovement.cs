using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGridMovement : BaseGridObject
{
    public float MoveSpeed;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    protected IntVector2 currentInputDirecion;
    private IntVector2 previousInputDirection;
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
        if(GridPos==targetGridPosition&&LevelGeneratorSystem.Grid[Mathf.Abs(GridPos.y+currentInputDirecion.y),GridPos.x+currentInputDirecion.x]!=1)
        {
            targetGridPosition += currentInputDirecion;
        }
        //if we set a new target and our current input is not valid->is a wall
        else  if(GridPos==targetGridPosition&& LevelGeneratorSystem.Grid[Mathf.Abs(GridPos.y + previousInputDirection.y), GridPos.x+previousInputDirection.x] != 1)
        {
            targetGridPosition += previousInputDirection;
        }
        if (GridPos == targetGridPosition) return;
        progressToTarget += MoveSpeed * Time.deltaTime;
        Debug.Log("base method...");
    }
}
