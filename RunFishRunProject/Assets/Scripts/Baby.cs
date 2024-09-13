using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Animation
{
    public GameObject BabyTrigger;
    public GameObject BabyNew;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (BabyTrigger.GetComponent<BabyTrigger>().TriggerTheBaby == true)
        {
            StartCoroutine(ActivateTheBaby());
        }
        if (BabyTrigger.GetComponent<BabyTrigger>().TriggerTheBaby == false)
        {
            ChangeAnimationState(animationNames[0]);
        }
    }

    private IEnumerator ActivateTheBaby()
    {
        ChangeAnimationState(animationNames[1]);
        yield return new WaitForSeconds(1f);
        Instantiate(BabyNew, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Destroy(Self);
    }

}
