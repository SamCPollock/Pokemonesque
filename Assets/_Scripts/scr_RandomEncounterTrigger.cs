using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RandomEncounterTrigger : MonoBehaviour
{
    [SerializeField]



    private void OnTriggerEnter2D(Collider2D collision)
    {
        scr_Player playerScript = collision.gameObject.GetComponent<scr_Player>();
        if (playerScript != null)
        {
            playerScript.isInRandomEncounterTrigger = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        scr_Player playerScript = collision.gameObject.GetComponent<scr_Player>();
        if (playerScript != null)
        {
            playerScript.isInRandomEncounterTrigger = false;
        }
    }
}
