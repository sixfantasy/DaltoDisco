using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyGetDamage>() != null)
            {
                collision.GetComponent<EnemyGetDamage>().DealDamage(damage);
            }
            GetComponent<Animator>().SetTrigger("Explode");
        }
    }
    public void OnDeathAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
