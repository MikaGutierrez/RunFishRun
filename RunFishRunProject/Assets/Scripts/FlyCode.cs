using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCode : MonoBehaviour
{
    public Rigidbody2D Self;
    public float FlyUp;
    public float FlyRight;
    // Start is called before the first frame update
    void Start()
    {
        Self.velocity = Vector2.up * FlyUp + Vector2.right * FlyRight;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
