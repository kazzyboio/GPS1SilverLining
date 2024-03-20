using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteractMeow : MonoBehaviour
{
    public bool inCat = false;   
    
     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCat = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCat = false;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCat == true)
        {
            FindObjectOfType<SoundManager>().Play("CatMeow");           
        }
    }
}
