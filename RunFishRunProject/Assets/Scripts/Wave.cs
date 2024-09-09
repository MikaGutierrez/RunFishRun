using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float moveInput = 5;
    public float speed;
    public float speedOfChange =1;
    private Rigidbody2D rb;
    public bool GoRight = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoRight == true)
        {
            moveInput -= Time.deltaTime * speedOfChange;
        }
        else
        {
            moveInput += Time.deltaTime * speedOfChange;
        }
        if (moveInput <= -5)
        {
            GoRight = false;
        }
        if (moveInput >= 5)
        {
            GoRight = true;
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private IEnumerator Run()
    {
        yield return new WaitForSeconds(100f);
        StartCoroutine(Run());
    }
}
