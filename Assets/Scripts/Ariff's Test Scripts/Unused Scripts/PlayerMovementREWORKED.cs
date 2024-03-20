using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementREWORKED : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    private Renderer rend;

    public float runSpeed = 0f;

    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        Debug.Log(crouch);

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }

        
        if (Input.GetButtonDown("Crawl"))
        {
            
            crouch = true;
        }
        else if (Input.GetButtonUp("Crawl"))
        {
            crouch = false;
        }
        
    }

    /*public void Crouch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            crouch = true;
        }
        else if (context.canceled)
        {
            crouch = false;
        }
    }*/

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("Crouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
