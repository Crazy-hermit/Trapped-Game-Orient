using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProc : MonoBehaviour
{
    public EnemySpawn assignedSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.instance.SpawnProc();
            assignedSpawn.Spawn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.instance.DespawnProc();
        }
    }
}
