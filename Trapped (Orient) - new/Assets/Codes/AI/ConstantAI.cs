using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantAI : EnemyAI
{
    /*
     * Script requirements:
     *  -Must be attached to an object
     */

    public float moveSpeed;

    void Update()
    {
        MoveToPlayer(moveSpeed);
    }
}
