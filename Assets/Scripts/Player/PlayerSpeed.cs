using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    const float SPEED_DECREASE_FACTOR = .1f;
    const float SPEED_MIN = .5f;

    [SerializeField] float speed = 2f;

    public float Speed
    {
        get { return speed; }
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerGrowth += DecreasePlayerSpeed;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerGrowth -= DecreasePlayerSpeed;
    }

    void DecreasePlayerSpeed()
    {
        if (speed >= SPEED_MIN)
            speed -= SPEED_DECREASE_FACTOR;
    }
}
