using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    /*
     * Script requirements:
     *  -Never attached to anything, attach child classes appropriately
     */

    //Continuously move towards the player, with variations on movement speed
    protected void MoveToPlayer(float moveSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, Manager.instance.playerPosition, Time.deltaTime * moveSpeed);
    }

    //Removes itself for respawn, spawner creates another instance in a set random range of values
    public void Despawn()
    {
        Destroy(gameObject);
    }
}
