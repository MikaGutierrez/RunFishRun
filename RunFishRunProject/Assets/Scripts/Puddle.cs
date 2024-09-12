using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public bool StopIt = false;
    public float lifeTime = 50;
    public float speed;
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;
    public Sprite Level4;
    public Sprite Level5;
    public Sprite Level6;
    public Sprite Level7;
    public GameObject Self;
    private SpriteRenderer sr;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && StopIt == false)
        {
            lifeTime = lifeTime - Time.deltaTime * 12 * speed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= 70 && lifeTime > 60)
        {
            sr.sprite = Level1;
        }
        else if (lifeTime <= 60 && lifeTime > 50)
        {
            sr.sprite = Level2;
        }
        else if (lifeTime <= 50 && lifeTime > 40)
        {
            sr.sprite = Level3;
        }
        else if (lifeTime <= 40 && lifeTime > 30)
        {
            sr.sprite = Level4;
        }
        else if (lifeTime <= 30 && lifeTime > 20)
        {
            sr.sprite = Level5;
        }
        else if (lifeTime <= 20 && lifeTime > 10)
        {
            sr.sprite = Level6;
        }
        else if (lifeTime <= 10 && lifeTime > 0)
        {
            sr.sprite = Level7;
        }
        else if (lifeTime <= 0)
        {
            Destroy(Self);
        }
    }
}
