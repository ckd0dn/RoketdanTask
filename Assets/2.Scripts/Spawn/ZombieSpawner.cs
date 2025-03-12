using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    private float _spawnInterval = 2f;
    private WaitForSeconds _wait;
    private void Start()
    {
        GameScene.Instance.StartLoadCallback += StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
        StartCoroutine(ChangeSpawnInterval());
    }

    private IEnumerator Spawn()
    {
        _wait = new WaitForSeconds(_spawnInterval);
        
        while (true)
        {
            ZombieMelee zombie = Managers.Object.Spawn<ZombieMelee>("ZombieMelee.prefab");
            zombie.transform.position = _spawnPos.position; 

            yield return _wait;
        }
    }

    private IEnumerator ChangeSpawnInterval()
    {
        yield return new WaitForSeconds(15f);
        
        _spawnInterval = 1f;
        _wait = new WaitForSeconds(_spawnInterval);
        
        yield return new WaitForSeconds(10f);

        _spawnInterval = .5f;
        _wait = new WaitForSeconds(_spawnInterval);

    }
}
