using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithFruits : Animation
{
    public bool DidFellDown = false;
    private bool YeldWork = false;
    public GameObject TheObjectFromBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && DidFellDown == false )
        {
            StartCoroutine(TriggerFell());
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DidFellDown == false && YeldWork == false)
        {
            ChangeAnimationState(animationNames[0]);
        }
        else if (DidFellDown == true && YeldWork == false)
        {
            ChangeAnimationState(animationNames[1]);
        }

        

}

    private IEnumerator TriggerFell()
    {
        YeldWork = true;
        ChangeAnimationState(animationNames[2]);
        yield return new WaitForSeconds(0.3f);
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.3f, transform.position.y + 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.1f, transform.position.y + 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));


        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.3f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));


        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.1f, transform.position.y - 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.3f, transform.position.y - 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.1f, transform.position.y - 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x + 0.2f, transform.position.y - 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));


        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.1f, transform.position.y + 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.2f, transform.position.y + 0.3f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.3f, transform.position.y + 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(TheObjectFromBox, new Vector3(transform.position.x - 0.2f, transform.position.y + 0.1f, 0f), Quaternion.Euler(0f, 0f, 0f));

        YeldWork = false;
        DidFellDown = true;
    }
}
