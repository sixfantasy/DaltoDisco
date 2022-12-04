using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void DealDamage(float damage)
    {

        health -= damage;
        CheckDeath();
    }
    public void HealCharacter(float heal)
    {
        health += heal;
    }

    private void CheckDeath()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}