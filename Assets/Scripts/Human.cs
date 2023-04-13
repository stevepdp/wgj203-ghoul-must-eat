using System.Collections;
using UnityEngine;

public class Human : MonoBehaviour
{
    const float FLIP_MIN_TIME = 0.25f;
    const float FLIP_MAX_TIME = 1f;

    IEnumerator humanSpriteFlip;
    SpriteRenderer spriteRenderer;
    bool keepLooking = true;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        HumanSetup();
    }

    void HumanSetup()
    {
        humanSpriteFlip = ChangeHumanFacing();
        StartCoroutine(humanSpriteFlip);
    }

    IEnumerator ChangeHumanFacing()
    {
        while (keepLooking)
        {
            if (spriteRenderer != null)
                spriteRenderer.flipX = !spriteRenderer.flipX;

            yield return new WaitForSeconds(Random.Range(FLIP_MIN_TIME, FLIP_MAX_TIME));
        }
    }
}
