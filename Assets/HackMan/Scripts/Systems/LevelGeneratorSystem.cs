using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelGeneratorSystem : MonoBehaviour
{    
    public Transform Origin;
    public int numbersOfLevel=10;
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
    private int currentLevelIndex;
    private void Awake()
    {
        currentLevelIndex = Random.Range(1, numbersOfLevel + 1);
        Debug.Log(currentLevelIndex);
        var grid = AppDataSystem.Load<int[,]>($"Level_{currentLevelIndex}.json");

        for (int y=0;y< grid.GetLength(0);y++)
        {
            for(int x=0;x< grid.GetLength(1);x++)
            {
              //  Instantiate(BaseGridObjectPrefabs[Grid[i, j]], Origin.position + new Vector3(j, -i, 0), Origin.rotation);
                var objectType = grid[y, x];
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPos = new IntVector2(x, -y);
                //Debug.Log(gridObjectClone.name+" "+gridObjectClone.GridPos.x + " " + gridObjectClone.GridPos.y);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPos.x, gridObjectClone.GridPos.y);
            }
        }
        LogObject();

    }


    [ContextMenu("Log Grid")]
    public void LogObject()
    {
        var obj = JsonConvert.SerializeObject(Grid);
        Debug.Log(obj);
    }

    [ContextMenu("Save Level")]
    public void SaveLevel()
    {
        AppDataSystem.Save(Grid,"Level_1.json");
    }

    [ContextMenu("Log Enemies")]
    public void LogEnemies()
    {

        var enemies = new List<ExampleEnemy>()
        {
            new ExampleEnemy(){HP=20},
            new ExampleEnemy(){HP=200},
            new ExampleEnemy(){HP=120},
            new ExampleEnemy(){HP=30},
            new ExampleEnemy(){HP=40},
            new ExampleEnemy(){HP=10},
            new ExampleEnemy(){HP=220},
            new ExampleEnemy(){HP=240},
            new ExampleEnemy(){HP=250}
        };
        var obj = JsonConvert.SerializeObject(enemies);
        Debug.Log(obj);
    }
    public void AnotherLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }
}

public class ExampleEnemy
{
    public int HP;
}
