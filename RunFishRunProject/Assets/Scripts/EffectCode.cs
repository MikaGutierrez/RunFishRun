using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCode : MonoBehaviour
{
    public float lifeTime = 50;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime = lifeTime - Time.deltaTime * 12;
        if (lifeTime <= 0)
        {
            Destroy(Self);
        }
    }
}
