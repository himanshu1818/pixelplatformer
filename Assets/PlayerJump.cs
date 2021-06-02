using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Public variables")]
    public float jumpForce;
    public bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;
    [Header("Private variables")]
    [SerializeField] private Transform point;
    [SerializeField] private float radiusOfCircle;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(point.position,radiusOfCircle,whatIsGround);
        if(Input.GetButtonUp("Jump")&& isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }
       

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(point.position, radiusOfCircle);
    }
}
