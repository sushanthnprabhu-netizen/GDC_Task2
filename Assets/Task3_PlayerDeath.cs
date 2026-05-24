using UnityEngine;
using UnityEngine.SceneManagement;

public class Task3_PlayerDeath : MonoBehaviour
{
    public Task3_GhostReplay ghostReplay;

    private void OnTriggerEnter2D(
        Collider2D other
    )
    {
        if (other.CompareTag("DeathZone"))
        {
            ghostReplay.StartReplayFromDeath();

            Invoke(
                nameof(RestartScene),
                10f
            );
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}