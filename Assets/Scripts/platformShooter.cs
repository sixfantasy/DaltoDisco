using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformShooter : MonoBehaviour
{
    float DestroyTimer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTimer -= Time.deltaTime;
        transform.position -= new Vector3(6 * Time.deltaTime, 0);
        if (DestroyTimer <= 0)
            Destroy(this.gameObject);
    }
}
