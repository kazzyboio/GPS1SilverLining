using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPull : MonoBehaviour
{
    //Variables
    private float horizontal;
    public float distance = 1f;
    public LayerMask boxMask;
    public Animator animator;
    
   
    private PlayerMovement pMovement;

    public NewPlayerMovement pm;

    public bool isPulling = false;

    GameObject box;

    Vector3 rayOrigin;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("pushable").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Physics2D.queriesStartInColliders = false;

        rayOrigin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * transform.localScale.x, distance, boxMask);
        //RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, Vector2.right * transform.localScale.x, distance, boxMask);

        //Debug.Log(hit.collider);
        //Debug.Log(hit.collider.gameObject.tag);


        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
        {            
            box = hit.collider.gameObject;        
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            isPulling = true;

        }

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable1" && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            isPulling = true;

        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
           
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
            isPulling = false;
            



        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(rayOrigin, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        //Gizmos.DrawWireSphere(transform.position, 2);
    }

    /*
    public void Pull(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && context.performed)
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
           


        }
        else if (context.canceled)
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
           
            

        }
        */

    }


