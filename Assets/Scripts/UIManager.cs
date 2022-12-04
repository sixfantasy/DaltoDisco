using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI DistanceTravelledText;
    private float _distanceTravelled;

    void Start() => _distanceTravelled = 0;

    void Update()
    {
        _distanceTravelled += ScrollManager.Instance.GetScrollSpeed() * Time.deltaTime;
        DistanceTravelledText.text = "Distance travelled: " + _distanceTravelled.ToString("0.00") + "m";
    }
}
