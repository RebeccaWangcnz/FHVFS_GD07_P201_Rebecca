using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQexample : MonoBehaviour
{
    //language
    //integrated
    //query
    private void OnEnable()
    {
        var names = new[] { "Gary", "Chloe", "Claire", "Rebecca", "Eazy", "Ben", "Kevin", "Giselle" };
        //Query syntax
        var namesWithAQuery = from name in names
                              where name.Contains('C')
                              select name;
        //Method syntax
        var namesWithAMethod = names.Where(name=>name.Contains('C'));
        foreach (var name in namesWithAQuery)
        {

        }
        //Method synax has more operator and methods, the compiler converts query syntax to methis syntax anyway...
        var enemies = new List<Enemy>()
        {
            new Enemy(){Name="Gary",HP=9000},
            new Enemy(){Name="Gary",HP=9000},
            new Enemy(){Name="Gary",HP=9000},
            new Enemy(){Name="Gary",HP=9000},
            new Enemy(){Name="Gary",HP=9000},
            new Enemy(){Name="Gary",HP=9000}
        };
        //filtering operator;filter a sequence based on some argument or criteria
        //lambda...=>
        var deadEnemies = enemies.Where(enemies => enemies.HP <= 0);
        //we could instead..
        var deadEnemiedBORing = new List<Enemy>();
        foreach (var enemy in enemies)
        {
            if(enemy.HP<=0)
            {
                deadEnemiedBORing.Add(enemy);
            }
        }
        foreach (var enemy in deadEnemies)
        {
            Debug.Log($"Dead enemy:{enemy.Name}");
        }
    }

    public class Enemy
    {
        public string Name;
        public int HP;
    }
}
