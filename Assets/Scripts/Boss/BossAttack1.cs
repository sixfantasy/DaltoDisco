using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public GameObject note;
    int Stage;
    float timer;
    float attackSpeed = 0.7f;
    float distanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Stage = GetComponent<BossStageManager>().Stage;
        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            if (Stage == 1)
            {
                timer = 0;
                Instantiate(note, transform.position + (Vector3.left+Vector3.up) * 2, Quaternion.identity * Quaternion.Euler(new Vector3(0, 0, Random.Range(-20, 20))));
            }
            if (Stage == 2)
            {
                timer = 0;
                Instantiate(note, transform.position + Vector3.left * 2, Quaternion.identity);
            }
          
        }

    }
}
