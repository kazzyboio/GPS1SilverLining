using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorOpen : MonoBehaviour
{
    private Animator anim;
    public bool inEBox = false;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Trapdoor1").GetComponent<Animator>();       
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
            anim.SetBool("trapdoorOpen", true);
            FindObjectOfType<SoundManager>().Play("TrapdoorOpen");
        }
    }
}
