using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDead;
    public static event Action OnPlayerGrowth;

    byte hp = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Human"))
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
