using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public abstract void MakeSound();
    
}

public class Snake : Animal
{
    public override void MakeSound()
    {
        Debug.Log("Snake hisses");
    }
}

public class Mammal : Animal
{
    public override void MakeSound()
    {
        Debug.Log("Mammal makes sound");
    }
}

public class Dog : Mammal
{
    public override void MakeSound()
    {
        Debug.Log("Dog barks");
    }
}

