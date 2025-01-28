using UnityEngine;
using UnityEngine.Pool;

public class Refact_Bullet : MonoBehaviour
{
    public Vector3 velocity = new(1f, 0f, 0f);

    // 5. Define a pool containing Refact_Bullet types.
    private IObjectPool<Refact_Bullet> m_pool;


    //6.Implement a public function to Set the pool from another script
    public void SetPool(IObjectPool<Refact_Bullet> pool)
    {
        m_pool = pool;
    }
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
        //7.Release this object to the pool when we are done with it, instead of destroying it.
        m_pool.Release(this);
    }
}
