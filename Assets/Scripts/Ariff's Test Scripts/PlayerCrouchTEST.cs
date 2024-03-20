using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS A PLACEHOLDER SCRIPT TO TEST THE CROUCHING FEATURE ONLY DONT CONSIDER THIS FINAL
//THIS USES GETKEYDOWN AND IT IS NOT LINKED TO THE CURRENT MOVEMENT SYSTEM YET
//IM STILL WORKING ON LINKING THE ANIMATIONS ON THE OTHER CODE

public class PlayerCrouchTEST : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;

    public Animator animator;

    public BoxCollider2D collider;

    public Sprite Standing;
    public Sprite Crouching;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    public Vector2 StandingOffset;
    public Vector2 CrouchingOffset;

    public float speed;

  

    // Start is called before the first frame update
    void Start()
    {

        collider = GetComponent<BoxCollider2D>();
        collider.size = StandingSize;
        collider.offset = StandingOffset;

        SpriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpriteRenderer.sprite = Crouching;
            collider.size = CrouchingSize;
            collider.offset = CrouchingOffset;
            animator.SetBool("Crouching", true);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            SpriteRenderer.sprite = Standing;
            collider.size = StandingSize;
            collider.offset = StandingOffset;
            animator.SetBool("Crouching", false);

        }
    }
}