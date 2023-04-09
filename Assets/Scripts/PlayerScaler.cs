using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    const float SCALE_MULTIPLYER = .25f;

    void OnEnable()
    {
        PlayerHealth.OnPlayerGrowth += SetPlayerScale;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerGrowth -= SetPlayerScale;
    }

    void SetPlayerScale()
    {
        transform.localScale = new Vector3(transform.localScale.x + SCALE_MULTIPLYER, transform.localScale.y + SCALE_MULTIPLYER, transform.localScale.z);
    }
}
