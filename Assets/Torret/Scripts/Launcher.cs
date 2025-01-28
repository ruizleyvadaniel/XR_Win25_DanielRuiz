using UnityEngine;

/// <summary>
/// Spawns SpawnObjects when  pressing the Space bar key
/// </summary>
public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet spawnPrefab;
    [SerializeField] Vector3 spawnObjectVelocity=new(2f,0f,0f);

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnPrefab.velocity = spawnObjectVelocity;
            Instantiate(spawnPrefab);
        }
    }
}
