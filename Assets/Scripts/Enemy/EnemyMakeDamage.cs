using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    public float damage;
    public float speed;

    public void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerStats.playerStats.DealDamage(damage);
        }
    }
}
