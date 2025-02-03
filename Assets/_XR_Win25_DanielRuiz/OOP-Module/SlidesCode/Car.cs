using UnityEngine;

public class Car : MonoBehaviour
{
    // Atrributes 
    private string manufacturer;
    private string model;
    private float currentSpeed;

    // Constructor to initialize the car's properties
    public Car(string manufacturer, string model, float initialSpeed)
    {
        this.manufacturer = manufacturer;
        this.model = model;
        this.currentSpeed = initialSpeed;
    }

    // Methods 
    public void Accelerate(float speed)
    {
        currentSpeed += speed;
    }
    public void DisplayInfo()
    {
        Debug.Log($"Car Info: Manufacturer: {manufacturer}, Model: {model}" +
            $",Current Speed: {currentSpeed} km/h");
    }
}
