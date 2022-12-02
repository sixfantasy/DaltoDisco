using UnityEngine;

public class Aim : MonoBehaviour
{
    public void AimAt(Vector2 direction)
    {
        direction.Normalize();
        transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
