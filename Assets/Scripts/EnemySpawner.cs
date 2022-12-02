using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    Camera cam;
    // Start is called before the first frame update
    float EnemyTimer;
    float EnemyTimer2;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        EnemyTimer = 0f;
        EnemyTimer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyTimer += Time.deltaTime;
        EnemyTimer2 += Time.deltaTime;


        if (EnemyTimer >= 3f)
        {
            Instantiate(enemy1, cam.ScreenToWorldPoint(new Vector3(Screen.width-200,Screen.height+200, 10)), Quaternion.identity);
            EnemyTimer = 0f;

        }
        if (EnemyTimer2 >= 10f)
        {
            Instantiate(enemy2, cam.ScreenToWorldPoint(new Vector3(Screen.width -200, Screen.height + 200, 10)), Quaternion.identity);
            EnemyTimer2 = 0f;
        }

    }
}