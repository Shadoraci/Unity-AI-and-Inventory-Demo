using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiPunch : EnemyAi
{
    public override void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!AlreadyAttacked)
        {
            //Punches with a trigger box

            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }
}
