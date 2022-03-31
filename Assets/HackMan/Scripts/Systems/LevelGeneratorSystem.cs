using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSystem : MonoBehaviour
{
    public Transform Origin;
    //1-->wall 0--->pill 2--->player 3--->ghost
    public BaseGridObject[] BaseGridObjectPrefabs;
    public static int[,] Grid = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1 },
        {1,0,1,0,0,0,0,3,0,1 },
        {1,0,2,0,1,0,1,0,1,1 },
        {1,0,1,0,1,0,0,0,0,1 },
        {1,0,1,0,1,0,1,1,0,1 },
        {1,0,0,0,0,0,0,3,0,1 },
        {1,1,1,1,1,1,1,1,1,1 }
    };

    private void Awake()
    {
        for(int y=0;y<Grid.GetLength(0);y++)
        {
            for(int x=0;x<Grid.GetLength(1);x++)
            {
              //  Instantiate(BaseGridObjectPrefabs[Grid[i, j]], Origin.position + new Vector3(j, -i, 0), Origin.rotation);
                var objectType = Grid[y, x];
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPos = new IntVector2(x, -y);
                //Debug.Log(gridObjectClone.name+" "+gridObjectClone.GridPos.x + " " + gridObjectClone.GridPos.y);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPos.x, gridObjectClone.GridPos.y);
            }
        }
    }
}
