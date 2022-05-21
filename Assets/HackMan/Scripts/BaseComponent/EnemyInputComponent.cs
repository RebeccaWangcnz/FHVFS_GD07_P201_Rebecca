using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputComponent :MovementComponent
{
    private IntVector2[] movementDirections = new IntVector2[]
    {
        IntVector2.up,
        IntVector2.down,
        IntVector2.left,
        IntVector2.right,
    };


    protected override void Update()
    {
        if (transform.position==targetGridPosition.ToVector3())
        {
            var possibleDirections = new List<IntVector2>();
            foreach (var movementDirection in movementDirections)
            {
                var potentialTargetPosition = targetGridPosition + movementDirection;

                if (!CanGoThrough(potentialTargetPosition)) continue;
                
                    //防止球来回移动 所以移动方向不能是先前方向的反方向
                    if(movementDirection!=-currentInputDirecion)
                    {
                        possibleDirections.Add(movementDirection);
                    }
                
            }
            //if we're at a dead end...
            if(possibleDirections.Count<1)
            {
                possibleDirections.Add(-currentInputDirecion);
            }
            var direction = Random.Range(0, possibleDirections.Count);
            currentInputDirecion = possibleDirections[direction];
        }
            base.Update();
    }
}
