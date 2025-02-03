using UnityEngine;

public class Client_Car : MonoBehaviour
{
    private Car car;
    void Start()
    {
        // Constructor to create the car with initial properties
        car = new Car("Tesla", "Model S", 0f);

        car.DisplayInfo();

        car.Accelerate(50f);  // Increase speed by 50 km/h

        car.DisplayInfo();
    }
}
