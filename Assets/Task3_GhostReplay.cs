using System.Collections.Generic;
using UnityEngine;

public class Task3_GhostReplay : MonoBehaviour
{
    public Task3_GhostRecorder recorder;

    private List<Task3_ReplayData> replayData;

    private int currentIndex;

    private bool startReplay;

    private float replayTimer;

    void Start()
    {
        replayData =
            new List<Task3_ReplayData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartReplayFromDeath();
        }

        if (startReplay)
        {
            ReplayMovement();
        }
    }

    public void StartReplayFromDeath()
    {
        replayData =
            new List<Task3_ReplayData>(
                recorder.replayData
            );

        currentIndex = 0;

        replayTimer = 0f;

        startReplay = true;
    }

    void ReplayMovement()
    {
        if (currentIndex >= replayData.Count)
        {
            startReplay = false;

            return;
        }

        replayTimer += Time.deltaTime;

        Task3_ReplayData currentData =
            replayData[currentIndex];

        if (
            replayTimer >=
            currentData.time
        )
        {
            transform.position =
                currentData.position;

            currentIndex++;
        }
    }
}