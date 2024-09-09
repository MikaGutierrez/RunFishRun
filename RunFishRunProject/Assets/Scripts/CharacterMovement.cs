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
    public GameObject GameOverPanel;
    public GameObject Ghost;
    private float GumForce = 1;

    //Rigidbody2D
    private Rigidbody2D rb;

    //Coroutine
    private bool YeldWork = false;
    private bool GameOverBool = false;
    private bool SendedGhsot = false;

    private bool StackIn = false;
    //Крабы
    private GameObject[] Crabs;
    private GameObject TheClousestCrab;
    private bool StackInCrab;
    private float MaxCrabfloat = 40;
    private float MinCrabfloat = 0;
    public float Crabfloat = 0;


    //Чайки
    private GameObject[] Seagulls;
    public GameObject TheClousestSeagull;
    private bool StackInSeagull;
    private float MaxSeagullfloat = 40;
    private float MinSeagullfloat = 0;
    public float Seagullfloat = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Puddle")
        {
            stamina = stamina + Time.deltaTime * staminaSpeed * 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SeagullTargete2")
        {
            GameOver();

        }
        if (collision.tag == "Baby")
        {
            GameOver();

        }
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
        if (collision.tag == "Crab")
        {
            StackIn = true;
            StackInCrab = true;
        }
        if (collision.tag == "Seagull")
        {
            StackIn = true;
            StackInSeagull = true;
        }
        if (collision.tag == "Gum")
        {
            GumForce = 0.45f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Gum")
        {
            GumForce = 1f;
        }
        
    }
    void Start()
    {
        Crabs = GameObject.FindGameObjectsWithTag("CrabTP");
        StopPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGameStopped = false;
        rb = GetComponent<Rigidbody2D>();
        //Char_Animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Seagulls = GameObject.FindGameObjectsWithTag("SeagullTP");

        if (isGrounded == false && YeldWork == false && StackInCrab == false)
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
        if (StackInCrab == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && YeldWork == false)
            {
                Crabfloat += 0.1f;
            }
            else
            {
                Crabfloat = Crabfloat - Time.deltaTime * 100;
            }

            transform.position = TheClousestCrab.transform.position;
            if (MaxCrabfloat <= Crabfloat)
            {
                StackInCrab = false;
                StackIn = false;
                rb.velocity = Vector2.up * 30;
                Crabfloat = 0;
            }
            if (MinCrabfloat >= Crabfloat)
            {
                Crabfloat = MinCrabfloat;
            }

        }

        if (StackInSeagull == true)
        {
            transform.eulerAngles = new Vector3(0, 0,-29.274f);
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && YeldWork == false)
            {
                Seagullfloat += 0.3f;
            }
            else
            {
                Seagullfloat = Seagullfloat - Time.deltaTime * 100;
            }

            transform.position = TheClousestSeagull.transform.position;
            if (MaxSeagullfloat <= Seagullfloat)
            {
                StackInSeagull = false;
                StackIn = false;
                rb.velocity = Vector2.up * -15;
                Seagullfloat = 0;
            }
            if (MinSeagullfloat >= Seagullfloat)
            {
                Seagullfloat = MinSeagullfloat;
            }

        }




        FindClousestCrab();
        FindClousestSeagull();
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
            GameOver();
        }
        if (YeldWork == false)
        {
            HeadRenderer.color = ColorNow;
            BodyRenderer.color = ColorNow;
            TailRenderer.color = ColorNow;
        }

        ColorNow = ColorRaw * (stamina * 0.01f) + ColorWellDone * (1 - stamina * 0.01f);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) && StackInCrab == false && YeldWork == false && GameOverBool == false)
        {         
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce * GumForce;

        }

        //if (isGrounded == true)
        //{
        //    Head_Animator.SetBool("IsMoving", false);
        //    Tail_Animator.SetBool("IsMoving", false);
        //}
        //else Head_Animator.SetBool("IsMoving", true);
        //Tail_Animator.SetBool("IsMoving", true);


        if (Input.GetKey(KeyCode.Space) && isJumping == true && YeldWork == false && StackIn == false && GameOverBool == false)
        {
            //Char_Animator.SetTrigger("Jump");
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }


        if (Input.GetKeyUp(KeyCode.Space) && YeldWork == false && StackIn == false)
        {
            isJumping = false;
        }



        if (Input.GetKeyDown("escape") && GameOverBool == false)
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
    //Врезался в машину
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

    //Найти Ближайшего Краба
    GameObject FindClousestCrab()
    {
        float distance = Mathf.Infinity;
        foreach (GameObject go in Crabs)
        { 
            Vector2 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            { 
                TheClousestCrab = go;
                distance = curDistance;
            }
        }
        return TheClousestCrab;
    }
    //Найти Ближайшеую чайку
    GameObject FindClousestSeagull()
    {
        float distance = Mathf.Infinity;
        foreach (GameObject go in Seagulls)
        {
            Vector2 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                TheClousestSeagull = go;
                distance = curDistance;
            }
        }
        return TheClousestSeagull;
    }
    //Конец
    public void GameOver()
    {
        if (SendedGhsot == false)
        {
            SendedGhsot = true;
            Instantiate(Ghost, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
        YeldWork = true;
        GameOverBool = true;
        GameOverPanel.SetActive(true);
    }
    //Конпки Меню
    public void ExitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void AgainClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PlayClick()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGameStopped = false;
    }



}
