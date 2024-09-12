using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CarCode : Animation
{
    public float lifeTime = 50;
    public GameObject Self;
    public Sprite[] CarSprites;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JustRun());
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


    private IEnumerator JustRun()
    {
        yield return new WaitForSeconds(0.3f);
        if (audioClips.Length > 0)
        {
            PlaySounds(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }
}
