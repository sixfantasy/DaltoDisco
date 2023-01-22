using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour
{
    public float damage;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyGetDamage>() != null)
            {
                collision.GetComponent<EnemyGetDamage>().DealDamage(damage);
                GetComponent<AudioSource>().PlayOneShot(sound);
            }
            GetComponent<Animator>().SetTrigger("Explode");
        }
    }
    public void OnDeathAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
