using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Animation
{
    private float moveInput;
    public float speed;
    private float speedWork = 1;
    private Rigidbody2D rb;
    private int RandomWay;
    public bool OnChillZone = false;
    private int Escape = 0;
    private bool YeldWork = false;
    public BoxCollider2D CrabCollider;
    public GameObject Claws;
    private bool CanEscape = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDeareection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ChillCrabZone" && OnChillZone == false && Claws.GetComponent<CrabClaws>().HaveAFish == false && YeldWork == false && CanEscape == true)
        {
            CanEscape = false;
            Escape = Random.Range(0, 2);
            OnChillZone = true;
            if (Escape == 1)
            {
                StartCoroutine(Hide());
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ChillCrabZone" && OnChillZone == true && YeldWork == false)
        {
            OnChillZone = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (YeldWork == false && Claws.GetComponent<CrabClaws>().HaveAFish == false)
        {
            ChangeAnimationState(animationNames[0]);
        }
        else if (YeldWork == false && Claws.GetComponent<CrabClaws>().HaveAFish == true)
        {
            ChangeAnimationState(animationNames[5]);
        }
        rb.velocity = new Vector2(moveInput * speed * speedWork, rb.velocity.y);
    }
    private IEnumerator Run1()
    {
        moveInput = 5;
        yield return new WaitForSeconds(2f);
        moveInput = 2.5f;
        yield return new WaitForSeconds(0.5f);
        moveInput = 0f;
        yield return new WaitForSeconds(0.05f);
        ChooseRandomDeareection();
    }
    private IEnumerator Run2()
    {
        moveInput = -5;
        yield return new WaitForSeconds(2f);
        moveInput = -2.5f;
        yield return new WaitForSeconds(0.5f);
        moveInput = 0f;
        yield return new WaitForSeconds(0.05f);
        ChooseRandomDeareection();
    }
    private IEnumerator Run3()
    {
        moveInput = 2.5f;
        yield return new WaitForSeconds(1f);
        moveInput = 1.25f;
        yield return new WaitForSeconds(0.25f);
        moveInput = 0f;
        yield return new WaitForSeconds(0.05f);
        ChooseRandomDeareection();
    }
    private IEnumerator Run4()
    {
        moveInput = -2.5f;
        yield return new WaitForSeconds(1f);
        moveInput = -1.25f;
        yield return new WaitForSeconds(0.25f);
        moveInput = 0f;
        yield return new WaitForSeconds(0.05f);
        ChooseRandomDeareection();
    }
    private IEnumerator Hide()
    {
        OnChillZone = true;
        CrabCollider.enabled = false;
        speedWork = 0;
        ChangeAnimationState(animationNames[2]);
        YeldWork = true;
        yield return new WaitForSeconds(0.5f);
        ChangeAnimationState(animationNames[4]);
        yield return new WaitForSeconds(Random.Range(1, 5));
        ChangeAnimationState(animationNames[1]);
        yield return new WaitForSeconds(0.7f);
        ChangeAnimationState(animationNames[4]);
        yield return new WaitForSeconds(Random.Range(1, 5));
        ChangeAnimationState(animationNames[3]);
        yield return new WaitForSeconds(0.7f);
        YeldWork = false;
        speedWork = 1;
        CrabCollider.enabled = true;
        yield return new WaitForSeconds(2f);
        CanEscape = true;
    }

    public void ChooseRandomDeareection()
    {
        RandomWay = Random.Range(0,4);
        if (RandomWay == 0)
        {
            StartCoroutine(Run1());
        }
        else if (RandomWay == 1)
        {
            StartCoroutine(Run2());
        }
        else if (RandomWay == 2)
        {
            StartCoroutine(Run3());
        }
        else if (RandomWay == 3)
        {
            StartCoroutine(Run4());
        }
    }

}
