using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityAI : EnemyAI
{
    public float moveSpeed;
    public float enemyRange;
    private float playerDistance;

    private Coroutine moveCor;

    private Rigidbody2D rb;

    void Update()
    {
        //Check if player is within specified enemy range by using distance formula
        if (Vector2.Distance(PlayerManager.instance.playerPosition, transform.position) <= enemyRange)
        {
            StopCoroutine(moveCor);
            MoveToPlayer(moveSpeed);
        }
    }

    private void patrol()
    {
        //Bootleg algortihm for patrolling
        moveCor = StartCoroutine(move());
    }

    public IEnumerator move()
    {
        //Move left for 3 secs, move right for 3 secs, stowp
        rb.velocity = new Vector2(-moveSpeed, 0f);
        yield return new WaitForSeconds(3f);
        rb.velocity = new Vector2(moveSpeed, 0f);
        yield return new WaitForSeconds(3f);
        rb.velocity = new Vector2(0f, 0f);
    }
}
