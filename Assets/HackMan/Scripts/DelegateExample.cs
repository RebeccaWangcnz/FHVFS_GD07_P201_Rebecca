using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DelegateExample : MonoBehaviour
{
    //The compiler converts this into a class...
    //class MeDelegate(£©
    //We can create a new object from it...
    public delegate void MeDelegate();
    public delegate bool MeDelegateInt(int n);
    public delegate int MeDelegateReturnInt();
    public delegate T MeDelegateGeneric<T>();
    //signiture: return .. takes...
    public void OnEnable()
    {
        //We're not invoking Foo, we are just passing it!
        MeDelegate meDelegate = new MeDelegate(Foo);
        
        //This is a reference to a class... but it's also treated like a method...
        //the compiler is helping us here,we can call/invoke it with...
        meDelegate.Invoke();
        //We can also invoke it like this..the compiler the compiler gives us this syntactic sugar
        meDelegate();
        //If we write it like this, the compiler will turn it into meDelegate.Invoke();

        //meDelegate references Foo,so it's a reference to an object, and a method...
       //This is some more syntactic sugar, ashorterway,but gets turned into the full bit in line15
        MeDelegate meDelegate1 = Goo;
        meDelegate1();

        //We're treating methods like first class objects
        //Wrap your heads around this...


        //Delegate are references to objects and methods
        Debug.Log($"Target:{meDelegate.Target}|Method:{meDelegate.Method}");
        Debug.Log($"Target:{meDelegate1.Target}|Method:{ meDelegate1.Method}");//no target for static function has no objects, it operates on class itself

        Debug.Log(Square(32324));
        //The same reason we parameterize this Square, is why we want to 3.  our code, or references to code methods)

        var results = GetAllNumbersleessThanFive(new List<int>() { 12,3,2,43,1,0,3,2,12,124});
        foreach (var result in results)
        {
            Debug.Log(result);
        }
        //How can we use Delegates to parameterize our GetAllNumberlessThan
        var numbers = new List<int>() { 11, 2, 3, 2, 2, 1, 3, 3 };
        //Here we'll just change the number...

        //Before the difference was just the number... but now we've changed the expression...we've changed the code
        var resultLessThanFive = RunNumbersThroughTheGaultlet(numbers, LessThanFive);
        resultLessThanFive.ForEach(result => Debug.Log($"Less than 5:{result}"));
        //This is kind of neat.. but we still need to making these method...LessThanFive
        var resultLessThanFive2 = RunNumbersThroughTheGaultlet(numbers,n=>n<5);//use lamda because the type is defined by lambda
        //var resultLessThanFive3 = RunNumbersThroughTheGaultlet(numbers, static bool Less5(int n){ return n < 5; });

        //delegate chaining 
        //We can add and remove delegates...
        MeDelegate meDelegate3 = Moo;
        meDelegate3 = (MeDelegate)Delegate.Combine(meDelegate3, (MeDelegate)Boo);
        meDelegate3 = meDelegate3 + Sue;
        meDelegate3 += Moo;
        meDelegate3 -= Moo;
        meDelegate3.Invoke();
        foreach (var d in meDelegate3.GetInvocationList())
        {
            Debug.Log($"Target:{d.Target}| Method:{d.Method}");
        }

        MeDelegateReturnInt meDelegateReturnInt = ReturnFive;
        meDelegateReturnInt += ReturnTen;
        var value = meDelegateReturnInt();
        Debug.Log(value);//return 10 get the last one
        foreach (var d in meDelegateReturnInt.GetInvocationList())
        {
            Debug.Log(d.DynamicInvoke());
        }//get 5 10

        MeDelegateGeneric<int> meDelegateGeneric = ReturnFive;
        meDelegateGeneric += ReturnTen;
        foreach (var value1 in GetAllReturnValue(meDelegateGeneric))
        {
            Debug.Log(value1);
        }
        //dON'T NEED TO MAKE delegat..
        //Microsoft has already make delegates
        //Func and Actions
        //Funcs have a return
        //Signiture of Func   
        Func<int> meDelegatefunc = ReturnFive;
        meDelegatefunc += ReturnTen;
        foreach (var value1 in GetAllReturnValueFunc(meDelegatefunc))
        {
            Debug.Log(value1);
        }
        // Func<int ,string> meDelegateIntString
        //Actions
        //All action return void
        Action<int> meDelegateAction = TakeAIntAndReturnVoid;
        meDelegateAction.Invoke(234);
        //The difference between delegates and events...
        //An event is a delegate with 2 restrictions: you can't assign to it directly, and you can't invoke it directly
        Action myAction = ATrainsAComin;
        myAction += ATrainsAComin;
      //  myAction = null;
        //myAction();

        var trainSignal = new TrainSignal();
        trainSignal.TrainAComing += ATrainsAComin;
       
        //trainSignal.TrainAComing = null;
        //trainSignal.TrainAComing.Invoke();

        //Event System
        //-Decouple code
        //loosely coupled yes   tightly coupled no  
    }

    private void ATrainsAComin()
    {
        Debug.Log("train");
    }
    public void TakeAIntAndReturnVoid(int obj)
    {
        Debug.Log($"Invoking our action:{obj}");
    }
    private static IEnumerable<T1> GetAllReturnValue<T1>(MeDelegateGeneric<T1> d)
    {
        foreach (MeDelegateGeneric<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }
    private static IEnumerable<T1> GetAllReturnValueFunc<T1>(Func<T1> d)
    {
        foreach (Func<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }
    private int ReturnTen() { return 10; }
    private int ReturnFive() { return 5; }
    static bool LessThanFive(int n)
    {
        return n < 5;
    }
    private List<int> RunNumbersThroughTheGaultlet(List<int> numbers,MeDelegateInt gauntlet)
    {
        return numbers.Where(number => gauntlet(number)).ToList();
    }
    private static List<int> GetAllNumbersleessThanFive(List<int> numbers)
    {
        return numbers.Where(number => number < 5).ToList();
    }
    private static List<int> GetAllNumbersleessThanTen(List<int> numbers)
    {
        return numbers.Where(number => number < 10).ToList();
    }
    public void InvokeTheDelegate(MeDelegate del)
    {
        del();
    }
    public void Foo()
    {
        Debug.Log("Foo");
    }
    public void Boo()
    {
        Debug.Log("Boo");
    }
    public void Sue()
    {
        Debug.Log("Hi, I'm Sue");
    }
    public static void Goo()
    {
        Debug.Log("Goo");
    }
    public static void Moo()
    {
        Debug.Log("Moo");
    }
    public int Square(int x)
    {
        return x * x;
    }
    public int SquareMessage(int x)
    {
        return x * x;
    }
    public string MultiplyAndReturnMessage(int x,int y)
    {
        return (x * y).ToString();
    }
}

public class TrainSignal
{
    public event Action TrainAComing;
    public void HereComesATrain()
    {
        TrainAComing?.Invoke();
    }
}

