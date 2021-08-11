using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector2 playerMoveInput;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Movement triggered");
        }

        playerMoveInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Interact triggered");
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("Player movement: " + playerMoveInput);
        rb.velocity = playerMoveInput * moveSpeed;
    }
}
