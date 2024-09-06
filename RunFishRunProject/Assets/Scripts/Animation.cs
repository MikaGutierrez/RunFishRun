using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animation;
    public string[] animationNames;
    private string currentState;
    //ChangeAnimationState(Name);

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animation.Play(newState);
        currentState = newState;
    }
}
