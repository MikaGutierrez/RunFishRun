using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animationNew;
    public string[] animationNames;
    private string currentState;
    //ChangeAnimationState(Name);

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animationNew.Play(newState);
        currentState = newState;
    }
}
