using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
    public float damage;
    public float projectileForce;
    public float shootCooldown = 3;
    private bool readyToFire = true;
    private BoxCollider2D collider2D;
    Vector2 shootCorrection = new Vector2(0, -2);
    bool isDrunk = false;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
       
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && collider2D != null && readyToFire==true)
        {
            GameObject spawn = Instantiate(projectile, collider2D.bounds.center, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (CubataManager.Instance.postProcessLayer.enabled)
            {
                mousePos += new Vector2(0, Random.Range(-3, 3));
            }
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos + shootCorrection).normalized;
            spawn.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spawn.GetComponent<projectiles>().damage = damage;
            readyToFire = false;
            StartCoroutine(FireCooldown());
        }
    }
    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        readyToFire = true;
    }
}
