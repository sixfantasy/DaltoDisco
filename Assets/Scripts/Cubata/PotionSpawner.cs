using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject cubata;
    Camera cam;
    float potionTimer;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        potionTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        potionTimer += Time.deltaTime;

        if (potionTimer >= 10f)
        {
            Instantiate(cubata, cam.ScreenToWorldPoint(new Vector3(Screen.width + 100, Screen.height + 200, 10)), Quaternion.identity);
            potionTimer = 0f;
        }
    }
}
