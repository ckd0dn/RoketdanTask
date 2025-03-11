using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Collider2D _collider;
    private float _spawnInterval = 1f;
    private void Start()
    {
        GameScene.Instance.StartLoadCallback += StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnInterval);
        
        while (true)
        {
            ZombieMelee zombie = Managers.Object.Spawn<ZombieMelee>("ZombieMelee.prefab");
            zombie.transform.position = _spawnPos.position; 

            yield return wait;
        }
    }
}
