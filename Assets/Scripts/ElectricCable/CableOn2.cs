using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableOn2 : MonoBehaviour
{   
    private Animator anim;
    public bool inEBox = false;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Obstacle2").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inEBox = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inEBox = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inEBox == true)
        {           
            anim.SetBool("danger", true);
        }
    }
}
