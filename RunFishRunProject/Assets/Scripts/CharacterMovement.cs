using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Color for Fish
    public SpriteRenderer HeadRenderer;
    public SpriteRenderer BodyRenderer;
    public SpriteRenderer TailRenderer;
    public Color ColorRaw;
    public Color ColorWellDone;
    public Color ColorDead;
    public Color ColorNow;

    //Stamina
    public float stamina = 100;
    public float staminaMin = 0;
    public float staminaMax = 100;
    public float staminaSpeed;
    public bool staminaWork = true;

    //For Movement
    public float speed;
    private float moveInput;

    //For Jump
    public float jumpForce;
    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    //For Rotation
    public float rotateSpeed;

    //Ground Check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public GameObject Player;
    //public Animator Tail_Animator;
   // public Animator Head_Animator;

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

        if (isGrounded == false)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (moveInput > 0)
            {
                transform.Rotate(Vector3.forward, -rotateSpeed);
            }
            else if (moveInput < 0)
            {
                transform.Rotate(Vector3.forward, rotateSpeed);
            }
        }
    }

    void Update()
    {
        if (staminaWork == true && staminaMin < stamina)
        { 
            stamina = stamina - Time.deltaTime * staminaSpeed;
        }
        if (staminaMax < stamina)
        {
            stamina = staminaMax;
        }
        if (staminaMin > stamina)
        {
            stamina = staminaMin;
        }
        HeadRenderer.color = ColorNow;
        BodyRenderer.color = ColorNow;
        TailRenderer.color = ColorNow;
        ColorNow = ColorRaw * (stamina* 0.01f) + ColorWellDone * (1 - stamina * 0.01f);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {         
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }

        //if (isGrounded == true)
        //{
        //    Head_Animator.SetBool("IsMoving", false);
        //    Tail_Animator.SetBool("IsMoving", false);
        //}
        //else Head_Animator.SetBool("IsMoving", true);
        //Tail_Animator.SetBool("IsMoving", true);


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


}
