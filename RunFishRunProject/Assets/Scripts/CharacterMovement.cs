using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    //Color for Fish
    public SpriteRenderer HeadRenderer;
    public SpriteRenderer BodyRenderer;
    public SpriteRenderer TailRenderer;
    public Color ColorRaw;
    public Color ColorWellDone;
    public static Color ColorNow;
    public Color ColorInvisible;

    //Stamina
    public float stamina = 100;
    public float staminaMin = 0;
    public float staminaMax = 100;
    public float staminaSpeed;
    public bool staminaWork = true;

    //For Movement
    private bool IsGameStopped;
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
    //GameObjects
    public GameObject SplashEffect;
    public GameObject FishWallEffect;
    public GameObject RespawnCarPlace;
    public GameObject StopPanel;

    //Rigidbody2D
    private Rigidbody2D rb;

    //Coroutine
    private bool YeldWork = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Puddle")
        {
            stamina = stamina + Time.deltaTime * staminaSpeed * 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Puddle")
        {
            Instantiate(SplashEffect, new Vector3(transform.position.x, transform.position.y - 0.34f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }

        if (collision.tag == "Car" && YeldWork == false) 
        {
            StartCoroutine(CrashWithCar());
        }

        if (collision.tag == "Leg")
        {
            StartCoroutine(GetALeg());
        }
    }
    void Start()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGameStopped = false;
        rb = GetComponent<Rigidbody2D>();
        //Char_Animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (isGrounded == false && YeldWork == false)
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
        if (staminaWork == true && staminaMin < stamina && YeldWork == false)
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
        if (YeldWork == false)
        {
            HeadRenderer.color = ColorNow;
            BodyRenderer.color = ColorNow;
            TailRenderer.color = ColorNow;
        }

        ColorNow = ColorRaw * (stamina * 0.01f) + ColorWellDone * (1 - stamina * 0.01f);

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


        if (Input.GetKey(KeyCode.Space) && isJumping == true && YeldWork == false)
        {
            //Char_Animator.SetTrigger("Jump");
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }


        if (Input.GetKeyUp(KeyCode.Space) && YeldWork == false)
        {
            isJumping = false;
        }



        if (Input.GetKeyDown("escape"))
        {
            if (IsGameStopped == false)
            {
                StopPanel.SetActive(true);
                IsGameStopped = true;
                Time.timeScale = 0f;
            }
            else if (IsGameStopped == true)
            {
                StopPanel.SetActive(false);
                Time.timeScale = 1f;
                IsGameStopped = false;
            }
        }
    }

    private IEnumerator CrashWithCar()
    {
        YeldWork = true;
        Instantiate(FishWallEffect, new Vector3(transform.position.x+1, transform.position.y+0.7f, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.01f);
        HeadRenderer.color = ColorInvisible;
        BodyRenderer.color = ColorInvisible;
        TailRenderer.color = ColorInvisible;
        yield return new WaitForSeconds(3.1f);
        transform.position = RespawnCarPlace.transform.position;
        HeadRenderer.color = ColorNow;
        BodyRenderer.color = ColorNow;
        TailRenderer.color = ColorNow;
        YeldWork = false;
    }
    private IEnumerator GetALeg()
    {
        YeldWork = true;
        rb.velocity = Vector2.up * 49 + Vector2.right * 20;
        yield return new WaitForSeconds(1.5f);
        YeldWork = false;
    }
    public void ExitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayClick()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGameStopped = false;
    }



}
