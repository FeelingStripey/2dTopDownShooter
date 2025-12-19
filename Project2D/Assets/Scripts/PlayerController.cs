using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 4.0f;

    public PlayerControls playerControls;
    public PlayerSettings playerSettings;

    private Vector2 movement;
    private Vector2 currentShootDirection;
    private Rigidbody2D rb;
    private Player player;

    private void Awake()
    {
        playerControls = new PlayerControls();
        //playerSettings = new PlayerSettings();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        if (playerControls.Attacks.Hit.ReadValue<float>() > 0)
        {
            if (movement != Vector2.zero)
            {
                if (player.state != EPlayerState.Shooting && 
                    player.state != EPlayerState.Dead &&
                    player.GetShootTimer() <= 0)
                {
                    currentShootDirection = movement;
                    player.SetState(EPlayerState.Shooting);
                }
            }
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (playerSettings.PlayerMoveSpeed * Time.fixedDeltaTime));
        if (movement.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1.0f;
            transform.localScale = scale;
        }
        else if (movement.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1.0f;
            transform.localScale = scale;
        }

    }

    public Vector2 getCurrentShootDirection()
    {
        return currentShootDirection;
    }
}
