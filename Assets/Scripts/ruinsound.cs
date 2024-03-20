using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruinsound : MonoBehaviour
{
    // Start is called before the first frame update

    public bool intheRange = false;
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            intheRange = true;
            FindObjectOfType<SoundManager>().Play("Ruin");
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            intheRange = false;
           
        }
    }
}
