using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange;

    public LayerMask playerLayer;

    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Patrol")]
    public Transform pointA;

    public Transform pointB;

    [Header("References")]
    public Transform player;

    protected bool playerDetected;

    protected bool isAlerted;

    protected Transform currentTarget;

    protected virtual void Start()
    {
        currentTarget = pointB;
    }

    protected virtual void Update()
    {
        DetectPlayer();

        if (playerDetected)
        {
            AlertNearbyEnemies();
        }
    }

    protected virtual void DetectPlayer()
{
    Collider2D hit =
        Physics2D.OverlapCircle(
            transform.position,
            detectionRange,
            playerLayer
        );

    if (hit != null)
    {
        playerDetected = true;

        player = hit.transform;
    }
    else
    {
        if (playerDetected)
        {
            ReturnToPatrol();
        }

        playerDetected = false;
    }
}

    protected virtual void AlertNearbyEnemies()
    {
        Collider2D[] nearbyEnemies =
            Physics2D.OverlapCircleAll(
                transform.position,
                8f
            );

        foreach (Collider2D enemy in nearbyEnemies)
        {
            EnemyManager enemyManager =
                enemy.GetComponent<EnemyManager>();

            if (
                enemyManager != null &&
                enemyManager != this
            )
            {
                enemyManager.ReceiveAlert(
                    player.position
                );
            }
        }
    }

    public virtual void ReceiveAlert(
        Vector3 playerPosition
    )
    {
        isAlerted = true;
    }

    protected virtual void Patrol()
    {
        if (
            pointA == null ||
            pointB == null
        )
        {
            return;
        }

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                currentTarget.position,
                moveSpeed * Time.deltaTime
            );

        if (
            Vector2.Distance(
                transform.position,
                currentTarget.position
            ) < 0.2f
        )
        {
            currentTarget =
                currentTarget == pointA
                ? pointB
                : pointA;
        }
    }

    protected virtual void ChasePlayer()
    {
        if (player == null)
            return;

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
    }

    protected virtual void ReturnToPatrol()
    {
        playerDetected = false;

        isAlerted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            detectionRange
        );
    }
}