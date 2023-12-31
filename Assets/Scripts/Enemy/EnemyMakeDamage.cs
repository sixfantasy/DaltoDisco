using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerStats.playerStats.DealDamage(damage);
            EnemyGetDamage enemyGetDamage = GetComponent<EnemyGetDamage>();
            enemyGetDamage.DealDamage(enemyGetDamage.maxHealth);
        }
    }
}
