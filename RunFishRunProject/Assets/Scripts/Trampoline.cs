using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline :Animation
{
    public Rigidbody2D rb;
    public float TrampolineForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = Vector2.up * TrampolineForce;
            PlaySounds(audioClips[0], p1: 1f, p2: 1.4f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
