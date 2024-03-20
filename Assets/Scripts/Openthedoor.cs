using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Openthedoor : MonoBehaviour
{
    private Animator anim;

    public bool isOpen;
    public bool InDoor = false;
 
    void Start()
    {      
        anim = GameObject.FindGameObjectWithTag("Gate").GetComponent<Animator>();          
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InDoor = true;           
        }
       
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InDoor = false;          
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InDoor==true)
        {
            isOpen = !isOpen;
            Destroy(GameObject.FindWithTag("CanvasInteract"));
            anim.SetBool("open", isOpen);
            FindObjectOfType<SoundManager>().Play("GateOpen");

        }
    }
}




