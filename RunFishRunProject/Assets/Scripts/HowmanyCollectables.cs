using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowmanyCollectables : MonoBehaviour
{
    public Text theText;
    public GameObject EIconCollect;
    public string Text1 = "Have you ever wanted to be at the top of a castle?";
    public string Text2 = "Have you ever gone rock climbing?";
    public string Text3 = "Jumping on a trampoline, I always think in different directions.";
    private int TextRadom;
    public int CollcetablesNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        EIconCollect.SetActive(false);
        TextRadom = Random.RandomRange(0, 3);
        CollcetablesNumber = CharacterMovement.CollectblesCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollcetablesNumber == 0)
        {
            if (TextRadom == 0)
            {
                theText.text = Text1;
            }
            else if (TextRadom == 1)
            {
                theText.text = Text2;
            }
            else if (TextRadom == 2)
            {
                theText.text = Text3;
            }
        }
        if (CollcetablesNumber != 0)
        {
            EIconCollect.SetActive(true);
            theText.text = "You collected " + CollcetablesNumber + " out of 3 radishes";

        }

    }
}
