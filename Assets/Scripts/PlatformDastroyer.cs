using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDastroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            Destroy(collision.transform.parent.gameObject);
        else
            Destroy(collision.gameObject);
            
    }

}
