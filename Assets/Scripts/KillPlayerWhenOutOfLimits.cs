using UnityEngine;

public class KillPlayerWhenOutOfLimits: MonoBehaviour
{
    public float spareLimits;

    void Update()
    {
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - spareLimits || transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - spareLimits)
        {} //TriggerPlayerDeath();
    }
}
