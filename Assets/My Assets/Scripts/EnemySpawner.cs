using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;

    private SpawnDirection _spawnDirection;    
    
    private bool _isSpawning = true;

    private void OnEnable()
    {
        StartCoroutine(SpawningEnemies());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawningEnemies());
    }

    private IEnumerator SpawningEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_isSpawning)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            GameObject enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);

            _spawnDirection = spawnPoint.GetComponent<SpawnDirection>();

            enemy.GetComponent<EnemyMovement>().SetDirection(_spawnDirection.ChosenDirection);

            yield return delay;
        }
    }
}