using UnityEngine;

public class MeleeEnemyManager : EnemyManager
{
    [Header("Melee Settings")]
    public float attackRange;

    public float attackCooldown;

    private bool canAttack = true;

    protected override void Update()
    {
        base.Update();

        if (playerDetected  && player != null)
        {
            ChasePlayer();

            if (
                Vector2.Distance(
                    transform.position,
                    player.position
                ) <= attackRange
            )
            {
                PerformAttack();
            }
        }
        else
        {
            Patrol();
        }
    }

    protected override void ChasePlayer()
    {
        base.ChasePlayer();
    }

    private void PerformAttack()
    {
        if (!canAttack)
            return;

        Debug.Log(
            gameObject.name +
            " attacked player!"
        );

        canAttack = false;

        Invoke(
            nameof(HandleAttackCooldown),
            attackCooldown
        );
    }

    private void HandleAttackCooldown()
    {
        canAttack = true;
    }
}