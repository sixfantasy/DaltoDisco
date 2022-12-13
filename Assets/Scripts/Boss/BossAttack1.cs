using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public GameObject note;
    float timer;
    float attackSpeed = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            timer = 0;
            Instantiate(note, transform.position + Vector3.left*2, Quaternion.identity);
        }

    }
}
