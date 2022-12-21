using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
    public float damage;
    public float projectileForce;
    private BoxCollider2D collider2D;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && collider2D != null)
        {
            GameObject spawn = Instantiate(projectile, collider2D.bounds.center, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            spawn.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spawn.GetComponent<projectiles>().damage = damage;
        }
    }
}
