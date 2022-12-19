using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{
    EnemyGetDamage damage;
    UIManager distanceReference;
    public int Stage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponent<EnemyGetDamage>();
        distanceReference = GameObject.Find("Managers").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceReference.DistanceTravelled > 200 && Stage == 0)
            Stage = 1;
        if (damage.health < 8 && Stage == 1)
            Stage = 2;
        if (damage.health < 3 && Stage == 2)
            Stage = 3;
        GetComponent<Animator>().SetInteger("Stage", Stage);


    }
}
