using System.Collections.Generic;
using UnityEngine;

public class Task3_GhostRecorder : MonoBehaviour
{
    [Header("Recording")]
    public float recordInterval = 0.1f;

    public List<Task3_ReplayData> replayData =
        new List<Task3_ReplayData>();

    private float timer;

    private float nextRecordTime;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextRecordTime)
        {
            RecordSnapshot();

            nextRecordTime =
                timer + recordInterval;
        }
    }

    void RecordSnapshot()
    {
        replayData.Add(
            new Task3_ReplayData(
                transform.position,
                timer
            )
        );
    }
}