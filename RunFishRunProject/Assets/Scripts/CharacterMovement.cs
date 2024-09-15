using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : Animation
{
    //Коллекционные предметы
    public static int CollectblesCount = 0;

    //Color for Fish
    public SpriteRenderer HeadRenderer;
    public SpriteRenderer BodyRenderer;
    public SpriteRenderer TailRenderer;
    public Color ColorRaw;
    public Color ColorMedium;
    public Color ColorWellDone;
    public static Color ColorNow;
    public Color ColorInvisible;

    //Stamina
    public float stamina = 200;
    public float staminaMin = 0;
    public float staminaMax = 200;
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
    public GameObject SplashBifEffect;
    public GameObject FishWallEffect;
    public GameObject RespawnCarPlace;
    public GameObject StopPanel;
    public GameObject GameOverPanel;
    public GameObject Ghost;
    public GameObject TapUI;
    public GameObject EffectDeath;
    public GameObject EffectGradient;
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
    private float MaxCrabfloat = 1;
    private float MinCrabfloat = 0;
    public float Crabfloat = 0;


    //Чайки
    private GameObject[] Seagulls;
    public GameObject TheClousestSeagull;
    private bool StackInSeagull;
    private float MaxSeagullfloat = 1;
    private float MinSeagullfloat = 0;
    public float Seagullfloat = 0;

    //Для звуков
    private bool FirstTimeOnGround;
    private bool FirstTimeOnPuddle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Puddle")
        {
            FirstTimeOnPuddle = true;
            stamina = stamina + Time.deltaTime * staminaSpeed * 6;
        }
        else
        {
            FirstTimeOnPuddle = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SeagullTargete2")
        {
            StartCoroutine(EndSeagull());
        }
        if (collision.tag == "Baby")
        {
            StartCoroutine(EndBaby());
        }
        if (collision.tag == "Puddle")
        {
            Instantiate(SplashEffect, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(-84.15f, 0f, 21.729f));
        }
        if (collision.tag == "StartFishParicle")
        {
            PlaySounds(audioClips[Random.Range(5, 7)], p1: 0.8f, p2: 0.8f);
            Instantiate(SplashBifEffect, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(-84.15f, 0f, 21.729f));
        }

        if (collision.tag == "Car" && YeldWork == false) 
        {
            StartCoroutine(CrashWithCar());
        }
        if (collision.tag == "Leg")
        {
            PlaySounds(audioClips[Random.Range(0, 5)], volume: 0.5f, p1: 0.8f, p2: 1.1f);
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
        CollectblesCount = 0;
        TapUI.SetActive(false);
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
        if (StackInCrab == true || StackInSeagull == true)
        {
            TapUI.SetActive(true);
        }
        else
        {
            TapUI.SetActive(false);
        }
        //Звуки
        if (isGrounded == true && FirstTimeOnGround == false)
        {
            FirstTimeOnGround = true;
            if (FirstTimeOnPuddle == false)
            {
                PlaySounds(audioClips[Random.Range(0, 5)],volume:0.5f, p1: 0.8f, p2: 1.1f);
            }
            else
            {
                PlaySounds(audioClips[Random.Range(5, 7)], p1: 0.8f, p2: 1.1f);
            }
        }

        if (isGrounded == false && FirstTimeOnGround == true)
        {
            FirstTimeOnGround = false;
        }
        //Застрял в крабе
        if (StackInCrab == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && YeldWork == false && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            {
                Crabfloat += 0.5f;
            }
            else
            {
                Crabfloat = Crabfloat - Time.deltaTime;
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
        //Застрял в чайке
        if (StackInSeagull == true)
        {
            transform.eulerAngles = new Vector3(0, 0,-29.274f);
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && YeldWork == false && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            {
                Seagullfloat += 0.5f;
            }
            else
            {
                Seagullfloat = Seagullfloat - Time.deltaTime;
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
            stamina = stamina - Time.deltaTime * staminaSpeed * 2;
        }
        if (staminaMax < stamina)
        {
            stamina = staminaMax;
        }
        if (staminaMin > stamina)
        {
            StartCoroutine(EndSun());
        }
        if (YeldWork == false)
        {
            HeadRenderer.color = ColorNow;
            BodyRenderer.color = ColorNow;
            TailRenderer.color = ColorNow;
        }
        if (stamina >= 100)
        {
            ColorNow = ColorRaw * ((stamina - 100) * 0.01f) + ColorMedium * (1 - (stamina - 100) * 0.01f);
        }
        else
        {
            ColorNow = ColorWellDone * ((stamina - 100) * -0.01f) + ColorMedium * (1 - (stamina - 100) * -0.01f);
        }

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
        yield return new WaitForSeconds(0.2f);
        PlaySounds(audioClips[7]);
        yield return new WaitForSeconds(0.5f);
        PlaySounds(audioClips[8]);
        yield return new WaitForSeconds(2.4f);
        transform.eulerAngles = new Vector3(0, 0, -141.25f);
        yield return new WaitForSeconds(0.0001f);
        rb.velocity = Vector2.right * 20 + Vector2.up * -10;
        transform.position = RespawnCarPlace.transform.position;
        HeadRenderer.color = ColorNow;
        BodyRenderer.color = ColorNow;
        TailRenderer.color = ColorNow;
        yield return new WaitForSeconds(1f);
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
        Time.timeScale = 1f;
        StartCoroutine(GoStart());
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


    private IEnumerator EndSun()
    {
        EffectDeath.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DeadBySun");
    }
    private IEnumerator EndSeagull()
    {
        EffectDeath.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DeadBySeagull");
    }
    private IEnumerator EndBaby()
    {
        EffectDeath.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DeadByBaby");
    }
    private IEnumerator GoStart()
    {
        EffectGradient.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
