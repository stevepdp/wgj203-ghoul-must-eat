using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _enemyPrefab;

    private IEnumerator _enemySpawner;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        _enemySpawner = SpawnEnemyRoutine();
        StartCoroutine(_enemySpawner);
    }

    void Update()
    {
        
    }

    public void OnGameOver()
    {
        _stopSpawning = true;
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-1.25f, 1.25f), Random.Range(-1.25f, 1.25f), 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            newEnemy.tag = "Enemy";
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // wait 3-5 seconds before spawning again
        }
    }
}
