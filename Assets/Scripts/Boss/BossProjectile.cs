using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioClip sound;
    public float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -12;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            GameObject.Find("Managers").GetComponent<PlayerStats>().DealDamage(damage);
            GetComponent<Animator>().SetTrigger("Explode");
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
        
    }
    public void OnDeathAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
