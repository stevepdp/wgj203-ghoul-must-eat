using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hp = 1;

    public static event Action OnPlayerDead;
    public static event Action OnPlayerGrowth;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hp++;
            if (GameManager.Instance != null)
                GameManager.Instance.TotalGhouls = hp;
            OnPlayerGrowth?.Invoke();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
            OnPlayerDead?.Invoke();
    }
}
