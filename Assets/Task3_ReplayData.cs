using UnityEngine;

[System.Serializable]
public class Task3_ReplayData
{
    public Vector3 position;
    public float time;

    public Task3_ReplayData(Vector3 pos, float t)
    {
        position = pos;
        time = t;
    }
}