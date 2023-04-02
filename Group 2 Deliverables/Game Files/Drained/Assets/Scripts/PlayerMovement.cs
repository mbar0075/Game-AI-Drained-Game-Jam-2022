using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declaring variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    //Declaring variables which will be used to map the ground
    [Header ("Ground Layer")]
    [SerializeField] private LayerMask jumpableGround;
    
    //Declaring variables for movement
    private float dirX = 0f;
    [Header ("Move Speed")]
    [SerializeField] private float moveSpeed = 7f;
    [Header ("Jump Force")]
    [SerializeField] private float jumpForce = 14f;


    //Declaring different states
    private enum MovementState { idle, 
                                running, 
                                jumping, 
                                falling}

    //Declaring variable for jump sound effect
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        //Intialising variables
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {   
        //Horizontal Movement
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Vertical Movement
        if ((Input.GetButtonDown("Jump")||Input.GetKey(KeyCode.W))&& IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        UpdateAnimationState();
    }

    //Method with updates animation states
    private void UpdateAnimationState()
    {
        MovementState state;

        //Checking horizontal Movement
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }


        //Checking vertical movement
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    //Method which checks if player is touching the ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}