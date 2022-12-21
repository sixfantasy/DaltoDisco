using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;

    public float health;
    public float maxHealth;

    public void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else playerStats = this;
        DontDestroyOnLoad(this);
    }
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
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player);
        }
    }
}
