using UnityEngine;
using UnityEngine.Pool;
/// <summary>
/// Refactored code for the ObjectSpawner class using object pooling pattern implementation by Unity.
/// https://docs.unity3d.com/6000.1/Documentation/ScriptReference/Pool.ObjectPool_1.html
/// </summary>
public class Refact_Launcher : MonoBehaviour
{
    [SerializeField] Refact_Bullet bulletPrefab;
    [SerializeField] Vector3 bulletVelocityAtFire = new(2f, 0f, 0f);

    // 1. Define a pool containing Refact_Bullet types.
    private IObjectPool<Refact_Bullet> m_bulletPool;

    private void Awake()
    {
        //2.Create a pool of the defined type. As arguments we will pass some fuctions
        m_bulletPool = new ObjectPool<Refact_Bullet>(CreateBullet, OnGet, OnRelease, OnActionDestroy,maxSize:25);

    }

    //3.Implement the functions passed as arguments before
    private Refact_Bullet CreateBullet()
    {
        Refact_Bullet bullet = Instantiate(bulletPrefab);
        bullet.velocity = bulletVelocityAtFire;
        bullet.SetPool(m_bulletPool);
        return bullet;
    }

    private void OnGet(Refact_Bullet bullet)
    {
       bullet.gameObject.SetActive(true);
       bullet.transform.SetPositionAndRotation(transform.position,transform.rotation);
    }

    private void OnRelease(Refact_Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    private void OnActionDestroy(Refact_Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //4. Get a bullet from the bullet pool instead of creating a new one. To Get a bullet we must first have bullets in the pool. This is done in the Bullet script.
            m_bulletPool.Get();
        }
    }
}
