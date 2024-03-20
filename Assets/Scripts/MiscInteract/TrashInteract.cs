using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteract : MonoBehaviour
{
    public bool inTrash = false;       
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Trash").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrash = true;
            anim.SetBool("inTrash", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrash = false;
            anim.SetBool("inTrash", false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrash == true)
        {
            FindObjectOfType<SoundManager>().Play("TrashPickup");
            anim.SetBool("TrashGone", true);           
        }
    }
}
