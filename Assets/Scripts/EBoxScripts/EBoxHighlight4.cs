using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EBoxHighlight4 : MonoBehaviour
{
    private Animator anim;
    public bool inRange = false;
    public bool isOn;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("EBox4").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            anim.SetBool("EBoxHighlight", true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            anim.SetBool("EBoxHighlight", false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            isOn = !isOn;
            anim.SetBool("EBoxActivated", isOn);
            FindObjectOfType<SoundManager>().Play("EBoxSparks");
        }

        else if (isOn)
        {
            if (Input.GetKeyDown(KeyCode.E) && inRange == true)
            {
                anim.SetBool("EBoxActivated", !isOn);
                FindObjectOfType<SoundManager>().Play("EBoxSparks");
            }
        }
    }
}
