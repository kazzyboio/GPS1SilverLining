using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    //Public Fields 

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    public float speed;
    public float jumpPower;

    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    Rigidbody2D rb;
    Animator animator;
    //[SerializeField] Collider2D standingCollider;
    [SerializeField] Transform groundCheckCollider;
    //[SerializeField] Transform overheadCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource climbingSound;


    float horizontalValue;
    float verticalValue;
    float runSpeedModifier = 2f;
   // float crouchSpeedModifier = 0.5f;

    [SerializeField] bool isGrounded;
    bool jump = false;
    public bool isFacingRight = true;
    bool isRunning;
    [SerializeField] bool crouchPressed;
    [SerializeField] bool isMoving; 


    public ParticleSystem dust;
    

    //Pulling Variables

    //public float distance = 1f;
    //public LayerMask boxMask;

    //GameObject box;

    public PlayerPull pPull;



    //Climbing Variables
    public float Climbspeed = 1f;
    public bool Climbing { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pPull = GetComponent<PlayerPull>();
        //footstep = GetComponent<AudioSource>();
        coll = GetComponent<BoxCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<scaffolding>() )
        {
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
        horizontalValue = Input.GetAxisRaw("Horizontal");
        
        verticalValue = Input.GetAxisRaw("Vertical") * Climbspeed;
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
                Jump();
                Debug.Log("Jump = True");
                jump = true;
                CreateDust();

        }
        /*
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        */
        /*
        if (Input.GetButtonDown("Crouch"))
        {
            crouchPressed = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouchPressed = false;
        }
        */
        if (Climbing == true && Input.GetKey(KeyCode.W) || Climbing == true && Input.GetKey(KeyCode.UpArrow))
        
        {
         //   rb.isKinematic = true;
            rb.velocity = new Vector2(horizontalValue, verticalValue);
            animator.SetBool("Climbing", true);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(horizontalValue, rb.velocity.y);
            animator.SetBool("Climbing", false);
        }
        /*
        #region Box Pull

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        Physics2D.queriesStartInColliders = false;

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;



        }



        #endregion
        */

        if (pPull.isPulling == true)
        {
            //Debug.Log("Pulling True");
            animator.SetBool("Pulling", true);
        }

        if(pPull.isPulling == false)
        {
            //Debug.Log("Pulling False");
            animator.SetBool("Pulling", false);
        }

        animator.SetBool("Climbing", Climbing);

        if(rb.velocity.x != 0)
        {
            isMoving = true;
            //FindObjectOfType<SoundManager>().Play("Walking");
        }
        else
        {
            isMoving = false;  
        }

        if(isMoving == true && isGrounded)
        {
                //walkSoundEffect.PlayOneShot(clip, 0.73f);
        }

        animator.SetFloat("yVelocity", rb.velocity.y);
        

        Debug.Log(rb.velocity.x);

    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue); //, jump);//crouchPressed);

        
    }

    void GroundCheck()
    {
        isGrounded = false;

        //Check if the GroundCheckObject is colliding with other
        //2D Collider that are in the "Ground" Layer
        //If yes (isGrounded true) else (isGrounded false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }

        //As long as were Grounded the "Jump" bool is disabled
        //In the animator is disabled
        animator.SetBool("Jumping", !isGrounded);



    }

    void Jump()
    {
        if (isGrounded)
        {
            animator.SetBool("Jumping", true);
            //rb.AddForce(new Vector2(0f, jumpPower));
            rb.velocity = Vector2.up * jumpPower;
        }

    }

    void Move(float dir) //bool jumpFlag) //bool crouchFlag)
    {
        //Debug.Log(jumpFlag);
        #region Jump and Crouch

        //If we are crouching and disabled crouching 
        //Check overhead for any ground items
        //If there are any, remained crouch , otherwise un-crouch
        /*
        if (!crouchFlag)
        {
            if (Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius, groundLayer))
            {
                crouchFlag = true;

            }
        }
        */

        //If Crouch is Pressed, Disable the standing collider + animate crouching
        //Reduce the speed
        //If released resume the original speed + enable the standing collider + disable animation 

        /*
        if (isGrounded)
        {
           // standingCollider.enabled = !crouchFlag;

            //If player is grounded and pressed space to jump
            if (jumpFlag)
            {
                isGrounded = false;
                jumpFlag = false;
                //Add jump force
                rb.AddForce(new Vector2(0f, jumpPower));
                Debug.Log("Jump = False");
            }
        }
        */

        
        /*
        if(pPull.isPulling == false) 
        { 
            animator.SetBool("Crouch", crouchFlag); 
        } else
        {
            animator.SetBool("Crouch", false);
        }
        */
        


        #endregion



        #region Move and Run
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        //If We Are Running Modifier
        /*
        if (isRunning == true)
        {
            xVal *= runSpeedModifier;
        }
        */
        /*
        if (crouchFlag)
        {
            xVal *= crouchSpeedModifier;
        }
        */
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        Vector3 currentScale = transform.localScale;

        //Player Flip
        
        if (isFacingRight && dir < 0 && pPull.isPulling == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }

        else if (!isFacingRight && dir > 0 && pPull.isPulling == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }

        //Debug.Log(rb.velocity.x);

        //0 idle, 10 walking, 20 running
        //Set the float xVelocity according to the speed value of the RigidBody2D

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        #endregion



    }

    //Gizmos for Pulling
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
    */

    void CreateDust()
    {
        dust.Play();
    }

   private void Footsteps()
    {
        footstep.Play();
    }

    private void ClimbingSound()
    {
        climbingSound.Play();
    }

    

    }


