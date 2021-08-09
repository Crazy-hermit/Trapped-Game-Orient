using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAI : EnemyAI
{
    private BoxCollider2D area;

    private bool playerInArea;
    public float moveSpeed;

    //Initialize necessary variables
    void Start()
    {
        playerInArea = false;
        area = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        //Move towards player if player is within assigned area
        if (playerInArea)
        {
            MoveToPlayer(moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if it is the player that entered the area
        if (collision.CompareTag("Player"))
        {
            playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Check if it is the player who exited the area
        if (collision.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }
}
