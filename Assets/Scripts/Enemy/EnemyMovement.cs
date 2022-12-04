using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponent<ScenarioScroll>().enabled = true;
    }
}
