using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : Animation
{
    public float speed = 1;
    public GameObject Target1;
    public GameObject Target2;
    public GameObject Self;
    public GameObject SelfS;
    private GameObject TargetMain;
    public float countH = 0;
    private bool GotAPlayer;
    private bool YeldWork = false;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SeagullTarget")
        {
            if (countH == 0)
            {
                TargetMain = Target2;
            }
            if (countH >= 1)
            {
                //Destroy(Self);
            }
        }

        if (collision.tag == "Player")
        {
            GotAPlayer = true;
            if (countH == 0)
            {
                TargetMain = Target2;
            }
        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SeagullTarget")
        {
            countH += 1;
        }
        if (collision.tag == "Player")
        {
            GotAPlayer = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TargetMain = SelfS;
        StartCoroutine(WaitStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetMain == Target1)
        {
            ChangeAnimationState(animationNames[0]);
        }
        //else if (YeldWork == true)
        //{
        //    ChangeAnimationState(animationNames[2]);
        //}
        else if (TargetMain == Target2)
        {
            ChangeAnimationState(animationNames[1]);
        }






        if (GotAPlayer == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RunA());
            }
            if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(RunD());
            }
        }
        if (YeldWork == false)
        {
            transform.position = Vector2.Lerp(transform.position, TargetMain.transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, TargetMain.transform.position, Time.deltaTime * speed * 0.25f);
        }
    }


    private IEnumerator RunA()
    {
        YeldWork = true;
        rb.velocity = Vector2.right * -2;
        yield return new WaitForSeconds(0.2f);
        YeldWork = false;
    }
    private IEnumerator RunD()
    {
        YeldWork = true;
        rb.velocity = Vector2.right * 2;
        yield return new WaitForSeconds(0.2f);
        YeldWork = false;
    }
    private IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1f);
        TargetMain = Target1;
    }
}
