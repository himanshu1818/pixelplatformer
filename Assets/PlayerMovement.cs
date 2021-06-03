using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]           // these will be attached to the player even if it is not been plaed beforehand on
[RequireComponent(typeof(Rigidbody2D))]        //the object this script is attached to
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;                    // rigidbody 2d component of the player for physics related stuff .
    private Animator anim;                     //animatror component of the player 
    [SerializeField]
    float playerSpeed;                         // speed of the player for movement 
   
    float movementInputDirection;                                // the input that Input.GetaxisRaw will get so to decide which side player should move in x direction (i.e 1,0,-1)
    private bool canJump;
    private bool isFacingRight;                  // to check if the playter is facing right 
    [SerializeField]
    private float jumpForce;
    private bool isWalking;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGround;
    bool isGrounded;
    [SerializeField]
    private float groundCheckRadius;
    public int amountOfJumps = 1;
    private int amountOfLeft;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        // get the component of the declred types
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //playerSpeed = 5f;    
        isFacingRight = true;
        amountOfLeft = amountOfJumps;
    }
   
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Flip(movementInputDirection);
        UpdateAnimations();
        CheckIfCanJump();

    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckForSurroundings();
      //  CheckIfCanJump();
    }

    //method for the flip of the player
    private void Flip(float horizontalValue)
    {
       if(horizontalValue<0 && isFacingRight || horizontalValue >0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
    //method for checking the input given by the player
    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            
        }
    }
    //method for the animations to play  
    void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isJumping", isJumping);

    }
    //check for the player input if he can jump or not so to avoid double jumping
    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            //canJump = true;
            amountOfLeft = amountOfJumps;
            
        }
        //if the player is grounded then isjumping must be false so that player can jump and animation can be played 
        if (isGrounded)
        {
            isJumping = false;
        }
        //if the player is not grounded then isjumping must be true as player is already jumping andmust come to idle state and animation can be played 
        if (!isGrounded)
        {
            isJumping = true;
        }
        if (amountOfLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }

    }
    // actual jump method for jumping the player
    private void Jump()
    {
        if (canJump)
        {
          
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfLeft--;
        }
    }

    // method for applying the movement of the player 
    void ApplyMovement()
    {
        rb.velocity = new Vector2(movementInputDirection * playerSpeed, rb.velocity.y);
    }
    // check for the player to be grounded if he's touching the ground
    void CheckForSurroundings()
    {
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    // gizmos to draw from the point of checkground gameobject for visual picture of the circle drawn from the point 
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
   
}
