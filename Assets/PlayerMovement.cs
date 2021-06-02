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
   
    float dirX;                                // the input that Input.GetaxisRaw will get so to decide which side player should move in x direction (i.e 1,0,-1)

    private bool facingRight;                  // to check if the playter is facing right 

    // Start is called before the first frame update
    void Start()
    {
        // get the component of the declred types
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //playerSpeed = 5f;    
        facingRight = true;
    }
    //we have written code separately for both jumping and flipping and flipping is here in this script and jumping will be in the next one
    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        // transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        anim.SetFloat("speed", Mathf.Abs(dirX));

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y) ;
        Flip(dirX);
    }

    private void Flip(float horizontalValue)
    {
       if(horizontalValue<0 && facingRight || horizontalValue >0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
