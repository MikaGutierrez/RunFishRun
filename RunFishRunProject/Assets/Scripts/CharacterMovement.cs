using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //For Movement
    public float speed;
    private float moveInput;

    //For Jump
    public float jumpForce;
    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    //Ground Check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public GameObject Player;
    //Animator Char_Animator;

    bool facingRight;


    //Rigidbody2D
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Char_Animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        if (moveInput > 0 && facingRight)
        {
            Flip();
            facingRight = false;
        }

        if (moveInput < 0 && !facingRight)
        {
            Flip();
            facingRight = true;
        }



        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }



        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            //Char_Animator.SetTrigger("Jump");
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.velocity = Vector2.up * -2 * jumpForce;
        }


    }

    private void Flip()
    {
        // Rotate the player
        if (transform.localEulerAngles.y != 180 && !facingRight)
            transform.Rotate(0f, -180f, 0f);
        else if (transform.localEulerAngles.y != 0 && facingRight)
            transform.Rotate(0f, 180f, 0f);
    }


}
