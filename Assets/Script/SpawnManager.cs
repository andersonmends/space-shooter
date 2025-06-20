using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _enemyConteiner;
    private bool _stopSpawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotRoutine());
       
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

            int powerupRandon = Random.Range(0, 3);
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_powerups[powerupRandon], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2,2));
        }
    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
