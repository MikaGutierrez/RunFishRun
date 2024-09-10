using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animationNew;
    public string[] animationNames;
    public AudioSource audioSr;
    public AudioClip[] audioClips;
    private string currentState;
    //ChangeAnimationState(Name);

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animationNew.Play(newState);
        currentState = newState;
    }

    public void PlaySounds(AudioClip clip, float volume = 1f, float p1 = 1f, float p2 = 1f)
    {
        audioSr.pitch = Random.Range(p1, p2);
        audioSr.PlayOneShot(clip, volume);
    }
}
