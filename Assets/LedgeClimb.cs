using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimb : MonoBehaviour
{
    public bool redBox, greenBox;
    public float redXOffset, redYOffset, redXsize, redYsize, greenXoffset, greenYoffset, greenXsize, greenYsize;
    private Rigidbody2D rb;
    public float startingGravity;
    [SerializeField]
    LayerMask wall;
    private bool isGrabbingEdge;
    private Animator myanim;
    private PlayerMovement player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
        myanim = GetComponent<Animator>();
        startingGravity = rb.gravityScale;
    }
    private void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (greenXoffset + transform.localScale.x), transform.position.y + (greenYoffset + transform.localScale.y)),new Vector2(greenXsize,greenYsize),0f,wall);
        redBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (redXOffset + transform.localScale.x), transform.position.y + (redYOffset + transform.localScale.y)), new Vector2(redXsize, redYsize), 0f, wall);
        if(greenBox && !redBox && player.isJumping)
        {
            isGrabbingEdge = true;
            // rb.velocity = new Vector2(0f, 0f);
            if (isGrabbingEdge)
            {
                rb.velocity = new Vector2(0f, 0f);
                rb.gravityScale = 0f;
            }
        }
        if(!greenBox && player.isJumping)
        {
            isGrabbingEdge = false;
            player.isJumping = false;
            rb.gravityScale = 4;
        }
       
       
        myanim.SetBool("isGrabbing", isGrabbingEdge);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + (redXOffset + transform.localScale.x), transform.position.y + (redYOffset + transform.localScale.y)), new Vector2(redXsize, redYsize));
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(transform.position.x + (greenXoffset + transform.localScale.x), transform.position.y + (greenYoffset + transform.localScale.y)), new Vector2(greenXsize, greenYsize));
    }
}
