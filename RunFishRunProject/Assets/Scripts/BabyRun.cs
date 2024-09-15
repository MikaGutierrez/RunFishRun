using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRun : Animation
{
    private Rigidbody2D rb;
    public GameObject Splash;
    public float speed;
    public float Acceleration;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StopTheBaby")
        {
            StartCoroutine(StopBaby());
        }
        if (collision.tag == "Player")
        {
            StartCoroutine(StopBaby2());
        }
    }
        void Start()
    {
        PlaySounds(audioClips[0]);
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
        PlaySounds(audioClips[1]);
        Instantiate(Splash, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(-84.15f, 0f, 21.729f));
        ChangeAnimationState(animationNames[1]);
        speed = 0f;
        Acceleration = 0;
        yield return new WaitForSeconds(1f);
        PlaySounds(audioClips[2]);
        ChangeAnimationState(animationNames[2]);

    }
    private IEnumerator StopBaby2()
    {
        ChangeAnimationState(animationNames[1]);
        speed = 0f;
        Acceleration = 0;
        yield return new WaitForSeconds(1f);
        ChangeAnimationState(animationNames[2]);

    }
}
