using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Animation
{
    public GameObject BabyTrigger;
    public BoxCollider2D cb;
    public float Acceleration;
    public float speed;
    public float BabyTimer;
    private bool IsBabyRun = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        cb.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BabyTrigger.GetComponent<BabyTrigger>().TriggerTheBaby == true && IsBabyRun == false)
        {
            IsBabyRun = true;
            StartCoroutine(ActivateTheBaby());
        }
        if (BabyTrigger.GetComponent<BabyTrigger>().TriggerTheBaby == false)
        {
            ChangeAnimationState(animationNames[0]);
        }
        if (IsBabyRun == true)
        {
            speed += Time.deltaTime * Acceleration;
        }
    }

    private IEnumerator ActivateTheBaby()
    {
        ChangeAnimationState(animationNames[1]);
        yield return new WaitForSeconds(1f);
        ChangeAnimationState(animationNames[2]);
        cb.enabled = true;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        yield return new WaitForSeconds(BabyTimer + 1);
    }
}
