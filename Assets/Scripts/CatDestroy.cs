using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDestroy : MonoBehaviour
{
    public Animator transition;
    
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            transition.SetTrigger("Start");
        }
    }
    
}
