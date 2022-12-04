using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    private static ScrollManager _instance;
    public static ScrollManager Instance { get => _instance; }

    // The speed and acceleration have to be positive due to ScenarioScroll.cs substracting position
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;

    public bool hasToScroll;

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this);
        _instance = this;
    }

    void Update()
    {
        if (hasToScroll)
            _speed += _acceleration * Time.deltaTime;
    }

    public float GetScrollSpeed()
    {
        if (!hasToScroll) return 0;
        return _speed;
    }
}
