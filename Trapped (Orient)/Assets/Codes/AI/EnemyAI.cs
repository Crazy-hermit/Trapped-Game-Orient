using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    //Continuously move towards the player, with variations on movement speed
    protected void MoveToPlayer(float moveSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerManager.instance.playerPosition, moveSpeed);
    }
}
