using UnityEngine;

public class Client_Animal : MonoBehaviour
{
    // Declare an array of Animal objects
    private Animal[] animals;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the array with 3 Animal objects (one for each type)
        animals = new Animal[3];

        // Instantiate and assign animals to the array
        animals[0] = new Snake();
        animals[1] = new Mammal();
        animals[2] = new Dog();

        // Loop through the array and call MakeSound on each animal
        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}
