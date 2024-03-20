using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHighlight : MonoBehaviour
{
    private Animator anim;
    public PlayerPull pPull;


    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("pushable").GetComponent<Animator>();
    }

    void Update()
    {
        if (pPull != null)
        {
            if (pPull.isPulling == true)
            {
                anim.SetBool("BoxHighlight", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("BoxHighlight", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("BoxHighlight", false);
        }
    }


}
