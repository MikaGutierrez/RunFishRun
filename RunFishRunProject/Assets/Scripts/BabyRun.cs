using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRun : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float Acceleration;
    // Start is called before the first frame update
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
}
