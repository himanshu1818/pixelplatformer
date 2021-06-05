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
    [SerializeField]
    Transform offset;
   
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
            //transform.position=new Vector2(transform.position.x,transform.position.y+2f);
            // rb.AddForce(new Vector2(transform.position.x, transform.position.y + 2f),ForceMode2D.Impulse);
            //player.GetComponent<BoxCollider2D>().offset = new Vector2(offset.position.x, offset.position.y);
            if (isGrabbingEdge)
            {
                rb.velocity = new Vector2(0f, 0f);
                rb.gravityScale = 0f;
            }
        }
        if(!greenBox)
        {
            isGrabbingEdge = false;
            player.isJumping = false;
            rb.gravityScale = startingGravity;
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
