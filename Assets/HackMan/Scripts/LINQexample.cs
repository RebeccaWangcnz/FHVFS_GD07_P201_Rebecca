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
            new Enemy(){Name="Gary",HP=9000,Age=47},
            new Enemy(){Name="Chris",HP=90,Age=12},
            new Enemy(){Name="Rebecca",HP=0,Age=32},
            new Enemy(){Name="Claire",HP=20,Age=43},
            new Enemy(){Name="Giselle",HP=43,Age=41},
            new Enemy(){Name="Chloe",HP=65,Age=23}
        };
        //filtering operator;filter a sequence based on some argument or criteria
        //lambda...=>
        var deadEnemies = enemies.Where(enemies => enemies.HP <= 0);//where: filtering operator
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
        //sorting operator: arrange elements in a collection (orderby, orderbydescending, thenby(used after orderby),thenbydescending
        var strongEnemyFirst = enemies.OrderBy(enemy => enemy.HP).ToList();
        strongEnemyFirst.ForEach(enemy => Debug.Log($"NAME:{enemy.Name}"));

        //Group by
        var groupedEnemiesByAge = enemies.GroupBy(enemy => enemy.Age);
        foreach (var group in groupedEnemiesByAge)
        {
            foreach (var enemy in group)
            {
                Debug.Log($"Group:{group}|Name:{enemy}");
             }
        }

        //Select not like where(filter) select can change the thing we get.  Aggregation
        var ages = enemies.Select(enemy => enemy.Age).OrderBy(age=>age).Skip(3);//skip: skip some datas
                                                                                                                                       // Take(3)            Take: take first some datas 
                                                                                                                                       //SkipWhile(age=>age>70)         don't return stuff until find one <=70
        var distinctAges = ages.Distinct();//remove duplicate
        foreach (var age in ages)
        {
            Debug.Log($"AGE:{age}");
        }
        foreach (var distinctAge in distinctAges)
        {
            Debug.Log($"DistinctAGE:{distinctAges}");
        }
        Debug.Log($"Total AGE: {ages.Sum()}");

        //All quantifier
        var isEveryoneNotSuperOld = enemies.All(enemy => enemy.Age < 100);
        var isAnyoneNotSuperOld = enemies.Any(enemy => enemy.Age < 100);

        var youngestEnemy = enemies.OrderBy(enemy => enemy.Age).FirstOrDefault();// return the youngerst enemy

    }

    public class Enemy
    {
        public string Name;
        public int HP;
        public int Age;
    }
}
