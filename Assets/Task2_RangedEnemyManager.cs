using UnityEngine;

public class RangedEnemyManager : EnemyManager
{
    [Header("Ranged Settings")]
    public float preferredDistance = 4f;

    public float shootingCooldown = 2f;

    private bool canShoot = true;

    protected override void Update()
    {
        base.Update();

        if (playerDetected)
        {
            MaintainDistance();

            if (canShoot)
            {
                ShootProjectile();
            }
        }
        else
        {
            Patrol();
        }
    }

    private void MaintainDistance()
    {
        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );

        if (distance < preferredDistance)
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    -moveSpeed * Time.deltaTime
                );
        }
        else
        {
            ChasePlayer();
        }
    }

    private void ShootProjectile()
    {
        Debug.Log(
            gameObject.name +
            " fired projectile!"
        );

        canShoot = false;

        Invoke(
            nameof(HandleShootCooldown),
            shootingCooldown
        );
    }

    private void HandleShootCooldown()
    {
        canShoot = true;
    }

    protected override void ChasePlayer()
    {
        base.ChasePlayer();
    }
}