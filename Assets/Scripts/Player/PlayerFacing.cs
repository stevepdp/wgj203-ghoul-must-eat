using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerFacing : MonoBehaviour
{
    const byte H_INPUT_THRES = 0;

    PlayerInput playerInput;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SetPlayerFacing();
    }

    void SetPlayerFacing()
    {
        if (playerInput != null && spriteRenderer != null)
        {
            if (playerInput.HorizontalInput < H_INPUT_THRES)
                spriteRenderer.flipX = true;

            if (playerInput.HorizontalInput > H_INPUT_THRES)
                spriteRenderer.flipX = false;
        }
    }
}
