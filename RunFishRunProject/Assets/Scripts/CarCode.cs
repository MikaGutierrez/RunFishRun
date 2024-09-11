using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CarCode : MonoBehaviour
{
    public float lifeTime = 50;
    public GameObject Self;
    public Sprite[] CarSprites;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = CarSprites[Random.Range(0, CarSprites.Length)];
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
