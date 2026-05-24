using UnityEngine;

public class ScoutManager : EnemyManager
{
    [Header("Scout Settings")]
    public Transform[] scanPoints;

    public float rotationSpeed = 2f;

    public float alertDuration = 5f;

    private int currentPointIndex;

    protected override void Update()
    {
        base.Update();

        if (!playerDetected)
        {
            ScanArea();
        }
        else
        {
            RaiseGlobalAlert();
        }
    }

    private void ScanArea()
    {
        if (scanPoints.Length == 0)
            return;

        Transform targetPoint =
            scanPoints[currentPointIndex];

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                targetPoint.position,
                rotationSpeed * Time.deltaTime
            );

        if (
            Vector2.Distance(
                transform.position,
                targetPoint.position
            ) < 0.2f
        )
        {
            currentPointIndex++;

            if (
                currentPointIndex >=
                scanPoints.Length
            )
            {
                currentPointIndex = 0;
            }
        }
    }

    private void RotateTowardsPoint()
    {

    }

    private void RaiseGlobalAlert()
    {
        Debug.Log(
            "Scout Camera detected player!"
        );

        AlertNearbyEnemies();
    }

    public override void ReceiveAlert(
        Vector3 playerPosition
    )
    {
        isAlerted = true;
    }
}