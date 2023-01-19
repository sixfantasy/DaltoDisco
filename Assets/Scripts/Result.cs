using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI DistanceTravelledText;
    private float DistanceTravelled;
    void Start()
    {
        DistanceTravelled = PlayerPrefs.GetFloat("DistanceTravelled");
        DistanceTravelledText.text = "Distance travelled: "+DistanceTravelled.ToString("0.00") +"m";
    }
}
