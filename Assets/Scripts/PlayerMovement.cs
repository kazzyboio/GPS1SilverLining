using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Declaration
    private float horizontal, vertical;
    public float Climbspeed = 1f;
    public float speed = 1.5f;
    public float jumpingPower = 2.8f;
    private bool isFacingRight;
    //public bool jumpTrigger = true;
    public Animator animator;

    GameObject player;
    public bool Climbing { get; set; }
    private PlayerPull pPull;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

 void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<scaffolding>())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePositionX;
            }
            Climbing = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.GetComponent<scaffolding>())
        {
            Climbing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical") * Climbspeed;

        if (Input.anyKey == false)
        {
            animator.SetBool("Walk", false);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal != 0)
        {
            rb.AddForce(new Vector2(horizontal * speed, 0f));
            animator.SetBool("Walk", true);
                
        }

        animator.SetBool("Climbing", Climbing);

        if (!isFacingRight && horizontal < 0f)
        {
            Flip();
            animator.SetBool("Walk", true);

            Debug.Log("Flipped Left");
        }

        if (isFacingRight && horizontal > 0f)
        {
            Flip();
            animator.SetBool("Walk", true);

            Debug.Log("Flipped Right");
        }
        if (Climbing && Input.GetKey(KeyCode.W))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(horizontal, vertical);
            animator.SetBool("Climbing", true);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(horizontal, rb.velocity.y);
            animator.SetBool("Climbing", true);
        }
    }
    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1f;
        transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }
    public void Jump(InputAction.CallbackContext context)
    {   
            if (context.performed && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                animator.SetBool("Jump", true);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                animator.SetBool("Jump", false);              
            }
        
    }
  
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
