using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubataCollission : MonoBehaviour
{
    public float cubataHeal;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            CubataManager.Instance.isDrunk=true;
            PlayerStats.playerStats.HealCharacter(cubataHeal);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponent<ScenarioScroll>().enabled = true;
    }
}
