using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearTuchCollider : MonoBehaviour
{
    public Color White;
    public Color Invisible;
    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    public bool ToDissapear;
    public float Speed = 1;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToDissapear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToDissapear = false;
        }
    }

    void Update()
    {
        if (ToDissapear == true && Speed <= 1 && Speed >= 0)
        {
            Speed -= Time.deltaTime * 0.7f;
        }
        if (ToDissapear == false && Speed <= 1 && Speed >= 0)
        {
            Speed += Time.deltaTime * 0.7f;
        }
        if (Speed > 1)
        {
            Speed = 1;
        }
        if (Speed < 0)
        {
            Speed = 0;
        }
        sr1.color = Speed * White;
        sr2.color = Speed * White;
    }

}
