using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenericExemple : MonoBehaviour
{
    public void OnEnable()
    {
        //getcomponent is a generic method
        //We can have generic methods AND generic classes
        var animator = gameObject.GetComponent<Animator>();

        var pairIntInt = new PairIntInt() { First = 5, Second = 65 };
        Debug.Log($"{pairIntInt.GetType()}|First:{pairIntInt.First}|Second:{pairIntInt.Second}");
        var pair1 = new Pair<string, string>() { first = "Bob", second = "Billy" };
        Debug.Log($"{pair1.GetType()}|First:{pair1.first}|Second:{pair1.second}");
        var pair2 = new Pair<string, float>() { first = "Bob", second = 36.5f };
        Debug.Log($"{pair2.GetType()}|First:{pair2.first}|Second:{pair2.second}");
        Debug.Log(pair1.GetType() == pair2.GetType());//return false


        //Use--- create new class
        MyClass<string>.Value = 10;
        MyClass<int>.Value = 23;
        MyClass<string>.Value = 20;//the constructor won't run
        MyClass<float>.Value = 746;

        //we can get 3 different values
        Debug.Log(MyClass<string>.Value);
        Debug.Log(MyClass<int>.Value);
        Debug.Log(MyClass<float>.Value);
        var numbers = new List<int>() { 123, 12, 12, 25, 4, 5 };
        PrintTheNumber(numbers);
        var returnNumbers = PrintTheThingReturnSome(numbers, 3);
        foreach (var returnNumber in returnNumbers)
        {
            Debug.Log($"Returned Name:{returnNumber}");
        }
        var names = new List<string>() { "Bob", "Billy", "Sarah" };
        PrintTheThing<string>(names);
        var classOne = Produce<ClassOne>();
    }

    //We can have generic classes, and we can also have generic method
    private void PrintTheNumber(List<int> numbers)
    {
        foreach (var number in numbers)
        {
            Debug.Log($"Number:{number}");
        }
    }
    private void PrintTheThing<T>(List<T> things)
    {
        foreach (var thing in things)
        {
            Debug.Log($"Thing:{thing}");
        }
    }
    private List<T> PrintTheThingReturnSome<T>(List<T> things,int returnCount)
    {
        foreach (var thing in things)
        {
            Debug.Log($"Thing:{thing}");
        }
        return things.Take(returnCount).ToList();
    }
    //I don't actually understand
    //Constrains are useful, and sometimes necessary, but the more you use...
    //The T must be ClassOne , so it's no longer a generic
    private T Produce<T>() where T:ClassOne, new()
    {
        T returnValue = new T();//use new the constructor is invoked
        returnValue.Setup();
        return returnValue;
    }

}
// this is a lot of duplication.. a lot of code to maintain.. and they MOSTLY do the same thing
public class PairIntInt
{
    public int First;
    public int Second;
}
public class PairIntFloat
{
    public int First;
    public float Second;
}
public class PairStringString
{
    public string First;
    public string Second;
}

public class Pair<T1,T2>
{
    public T1 first;
    public T2 second;
}
public class MyClass<T>
{
    public static int Value;
    //static constructor: run once it only runs the first time.
    static MyClass()
    {
        Debug.Log(typeof(MyClass<T>));
    }
}
//We can put constraints on our generic type arguments...
public class ClassOne
{
    public void Setup()
    {
        Debug.Log("fufufufufu");
    }
}