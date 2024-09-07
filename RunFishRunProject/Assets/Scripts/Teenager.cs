using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Teenager : MonoBehaviour
{
    public SpriteRenderer RLeg;
    public SpriteRenderer LLeg;
    public Sprite LegUp;
    public Sprite LegDown;
    public BoxCollider2D RLegCollider;
    public BoxCollider2D LLegCollider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTeenager());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator StartTeenagerOld()
    {
        RLeg.sprite = LegUp;
        LLeg.sprite = LegUp;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegDown;
        LLeg.sprite = LegUp;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegDown;
        LLeg.sprite = LegDown;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegUp;
        LLeg.sprite = LegDown;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegUp;
        LLeg.sprite = LegUp;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegUp;
        LLeg.sprite = LegDown;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegDown;
        LLeg.sprite = LegDown;
        yield return new WaitForSeconds(0.45f);
        RLeg.sprite = LegDown;
        LLeg.sprite = LegUp;
        yield return new WaitForSeconds(0.45f);
        StartCoroutine(StartTeenagerOld());
    }

    private IEnumerator StartTeenager()
    {
        RLeg.sprite = LegDown;
        LLeg.sprite = LegUp;
        LLegCollider.enabled = true;
        yield return new WaitForSeconds(0.05f);
        LLegCollider.enabled = false;
        yield return new WaitForSeconds(1f);


        RLeg.sprite = LegUp;
        LLeg.sprite = LegDown;
        RLegCollider.enabled = true;
        yield return new WaitForSeconds(0.05f);
        RLegCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartTeenager());
    }
}
