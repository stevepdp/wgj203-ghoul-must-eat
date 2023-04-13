using System.Collections;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    const float SPAWN_RANGE_MIN = -1.25f;
    const float SPAWN_RANGE_MAX = 1.25f;
    const float SPAWN_MIN_TIME = 2f;
    const float SPAWN_MAX_TIME = 4f;

    [SerializeField] GameObject humanContainer;
    [SerializeField] GameObject humanPrefab;

    IEnumerator humanSpawner;
    bool stopSpawning = false;

    void OnEnable()
    {
        GameManager.OnGameOver += StopSpawning;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= StopSpawning;
    }

    void Start()
    {
        SetSpawner();
    }

    void SetSpawner()
    {
        humanSpawner = SpawnEnemyRoutine();
        StartCoroutine(humanSpawner);
    }

    void StopSpawning()
    {
        stopSpawning = true;
        StopCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (stopSpawning == false)
        {
            if (humanContainer != null && humanPrefab != null)
            {
                GameObject newHuman = Instantiate(humanPrefab, new Vector3(Random.Range(SPAWN_RANGE_MIN, SPAWN_RANGE_MAX), Random.Range(SPAWN_RANGE_MIN, SPAWN_RANGE_MAX), 0), Quaternion.identity);
                newHuman.transform.parent = humanContainer.transform;
                newHuman.tag = "Human";
            }

            yield return new WaitForSeconds(Random.Range(SPAWN_MIN_TIME, SPAWN_MAX_TIME));
        }
    }
}
