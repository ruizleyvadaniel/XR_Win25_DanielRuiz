using UnityEngine;

/// <summary>
/// This script controls an object that moves at a constant speed and direction, and 
/// self-destructs when is no visible by the camera.
/// </summary>
public class Bullet : MonoBehaviour
{
   public Vector3 velocity = new(1f,0f,0f);

    void Update()
    {
        // Moves the object at a consistent velocity. 
        // Multiplying by Time.deltaTime ensures smooth movement 
        // regardless of the frame rate.
        transform.position += velocity * Time.deltaTime;
    }

    /// <summary>
    /// Auto destory when no longer within the camera's frame
    /// </summary>
   void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
