using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubataCollission : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Nose que posar xd
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponent<ScenarioScroll>().enabled = true;
    }
}
