using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _powerupTripleShotPrefab;
    [SerializeField]
    private GameObject _speedupPrefab;
    [SerializeField]
    private GameObject _shieldupPrefab;
    [SerializeField]
    private GameObject _enemyConteiner;
    private bool _stopSpawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotRoutine());
        StartCoroutine(SpawnShieldupRoutine());
        StartCoroutine(SpawnSpeedupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyConteiner.transform;
            yield return new WaitForSeconds(5.0f);
        }


    }

    IEnumerator SpawnTripleShotRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_powerupTripleShotPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,15));
        }
    }

    IEnumerator SpawnSpeedupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_speedupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }

    IEnumerator SpawnShieldupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_shieldupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
