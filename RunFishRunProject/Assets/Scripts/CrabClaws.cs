using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabClaws : MonoBehaviour
{
    public bool HaveAFish;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HaveAFish = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HaveAFish = false;
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
