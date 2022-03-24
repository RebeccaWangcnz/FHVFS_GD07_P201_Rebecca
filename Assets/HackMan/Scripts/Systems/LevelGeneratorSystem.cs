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
        for(int i=0;i<Grid.GetLength(0);i++)
        {
            for(int j=0;j<Grid.GetLength(1);j++)
            {
              //  Instantiate(BaseGridObjectPrefabs[Grid[i, j]], Origin.position + new Vector3(j, -i, 0), Origin.rotation);
                var objectType = Grid[i, j];
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPos = new IntVector2(i, j);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPos.x, gridObjectClone.GridPos.y,0);
            }
        }
    }
}
