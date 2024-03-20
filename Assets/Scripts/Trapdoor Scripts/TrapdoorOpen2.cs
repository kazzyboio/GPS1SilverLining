using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorOpen2 : MonoBehaviour
{
    private Animator anim;

    public bool isOpen;
    public bool inEBox = false;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Trapdoor3").GetComponent<Animator>();       
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
            isOpen = !isOpen;
            anim.SetBool("trapdoorOpen", isOpen);
        }
    }
}
