using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformDastroyer : MonoBehaviour
{
    public bool disablePlatformDestruction = false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !disablePlatformDestruction)
            Destroy(collision.transform.parent.gameObject);
        else if (collision.tag != "Ground")
            Destroy(collision.gameObject);
            
    }

}
