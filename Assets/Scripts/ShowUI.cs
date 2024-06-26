using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{   
    public Canvas ButtonPrompt;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {           
            ButtonPrompt.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {          
            ButtonPrompt.enabled = false;
        }
    }   
}
