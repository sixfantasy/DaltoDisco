using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI DistanceTravelledText;
    public float DistanceTravelled;

    void Start() => DistanceTravelled = 0;

    void Update()
    {
        DistanceTravelled += ScrollManager.Instance.GetScrollSpeed() * Time.deltaTime;
        DistanceTravelledText.text = "Distance travelled: " + DistanceTravelled.ToString("0.00") + "m";
    }
}
