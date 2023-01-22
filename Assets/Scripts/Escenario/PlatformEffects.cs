using UnityEngine;

public class PlatformEffects : MonoBehaviour
{
    public string effect;
    [SerializeField] private PhysicsMaterial2D _bouncyMaterial;

    private void Start()
    {
        switch (effect)
        {
            case "Bouncy":
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial = _bouncyMaterial;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (effect)
        {
            case "BoostSpeed":
                ScrollManager.Instance.MultiplyAcceleration(1.5f);
                break;
            case "LowerSpeed":
                ScrollManager.Instance.MultiplyAcceleration(0.75f);
                break;
        }
    }
}
