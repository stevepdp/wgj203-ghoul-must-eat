using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerSpeed))]
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerSpeed playerSpeed;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerSpeed = GetComponent<PlayerSpeed>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (playerInput != null && playerSpeed != null)
        {
            transform.Translate(Vector3.right * playerInput.HorizontalInput * playerSpeed.Speed * Time.deltaTime);
            transform.Translate(Vector3.up * playerInput.VerticalInput * playerSpeed.Speed * Time.deltaTime);
        }
    }
}
