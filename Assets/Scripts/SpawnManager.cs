using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _spawnRange = 9f;

    void Start()
    {
        SpawnEnemyWave(3);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn;  i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPositionZ = Random.Range(-_spawnRange, _spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return randomPosition;
    }
}