using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BabyRun : Animation
{
    private Rigidbody2D rb;
    public float speed;
    public float Acceleration;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StopTheBaby")
        {
            StartCoroutine(StopBaby());
        }
    }
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * Acceleration;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    private IEnumerator StopBaby()
    {
        ChangeAnimationState(animationNames[1]);
        speed = 0f;
        Acceleration = 0;
        yield return new WaitForSeconds(1f);
        ChangeAnimationState(animationNames[2]);

    }
}
