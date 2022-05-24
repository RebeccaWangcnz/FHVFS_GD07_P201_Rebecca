using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public BaseGridObject playerPart;
    //private int distance=3;
    private IntVector2[] positions = new IntVector2[]
    {
        IntVector2.up,
        IntVector2.down,
        IntVector2.left,
        IntVector2.right,
    };
    private void OnEnable()
    {
        Evently.Instance.Subscribe<UpgradeEvent>(OnUpgraded);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<UpgradeEvent>(OnUpgraded);
    }
    private void OnUpgraded(UpgradeEvent evt)
    {
        int num = Random.Range(0, evt.blankPos.Length - 1);
        var part = Instantiate(playerPart);
        part.GridPos = evt.blankPos[num].GridPos;
        //Debug.Log(gridObjectClone.name+" "+gridObjectClone.GridPos.x + " " + gridObjectClone.GridPos.y);
        part.transform.position = new Vector3(part.GridPos.x, part.GridPos.y);
        //foreach (var position in positions)
        //{
        //    var potentialTargetPosition = evt.position +new IntVector2( position.x*distance,position.y*distance);
        //    if(potentialTargetPosition.IsPill()|| (potentialTargetPosition.IsWall()&&FindWall(potentialTargetPosition).GetComponent<Wall>().fake))
        //    {
        //        var part=Instantiate(playerPart);
        //        part.GridPos = potentialTargetPosition;
        //        //Debug.Log(gridObjectClone.name+" "+gridObjectClone.GridPos.x + " " + gridObjectClone.GridPos.y);
        //        part.transform.position = new Vector3(part.GridPos.x, part.GridPos.y);
        //        break;
        //    }

        //}
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
