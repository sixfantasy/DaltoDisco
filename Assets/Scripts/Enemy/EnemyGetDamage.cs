using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void DealDamage(float damage)
    {

        health -= damage;
        animator.SetTrigger("Hit");
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
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("Die");
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}