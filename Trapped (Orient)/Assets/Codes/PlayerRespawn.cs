using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    /*
     * Script requirements:
     *  -Must be attached to an object which has the hitbox of the player
     *  -Attached object must have a collider2D (or any of its child classes e.g., boxcollider2d, circlecollider2d)
     */

    private void Start()
    {
        //Set default playerSpawn to initial location when the scene starts
        Manager.instance.playerSpawn = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //All enemies must have the "Enemy" tag to trigger respawn procedures
        if (collision.CompareTag("Enemy"))
        {
            Manager.instance.RespawnProc();
        } 
        //All checkpoints must have the "Checkpoint" tag to be set as a respawn point
        else if (collision.CompareTag("Checkpoint"))
        {
            Manager.instance.playerSpawn = collision.bounds.center;
        }
    }
}
