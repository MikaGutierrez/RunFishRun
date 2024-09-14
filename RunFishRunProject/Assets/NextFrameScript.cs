using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFrameScript : MonoBehaviour
{
    public Animator Cutscene;
 
    // Update is called once per frame
    private void OnMouseDown()
    {
        Cutscene.SetTrigger("IsClicked");
    }
}
