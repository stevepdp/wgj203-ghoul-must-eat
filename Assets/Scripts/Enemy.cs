using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnumerator _enemySpriteFlip;
    private bool _stopSpawning = false;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _enemySpriteFlip = SpawnEnemyRoutine();
        StartCoroutine(_enemySpriteFlip);
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            yield return new WaitForSeconds(Random.Range(0.25f, 1f)); // wait 3-5 seconds before spawning again
        }
    }
}
