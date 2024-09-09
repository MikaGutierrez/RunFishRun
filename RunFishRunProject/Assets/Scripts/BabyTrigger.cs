using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTrigger : MonoBehaviour
{
    public bool TriggerTheBaby = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerTheBaby = true;
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
