using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /*
     * Script requirements:
     *  -Must be attached to an empty object
     *  -Manual enemy prefab assignment
     */

    public float spawnWidth, spawnHeight;
    public GameObject enemy;
    private Vector2 spawnLoc;
    private float minWidth, maxWidth, minHeight, maxHeight;

    //Disable initial respawn call in start method when enemy is not intended to spawn initially
    private void Start()
    {
        //Spawn();
    }

    public void Spawn()
    {
        //Spawn width calculations
        minWidth = transform.position.x - spawnWidth / 2;
        maxWidth = transform.position.x + spawnWidth / 2;

        //Spawn height calculations
        minHeight = transform.position.y - spawnHeight / 2;
        maxHeight = transform.position.y + spawnHeight / 2;

        //Spawn location calculation, random range between previously calculated minimum and maximum values (inclusive)
        spawnLoc = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
        Instantiate(enemy, spawnLoc, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos to draw spawn range
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(spawnWidth, spawnHeight));
    }
}
