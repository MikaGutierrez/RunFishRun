using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCode : Animation
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlaySounds(audioClips[0],volume:0.3f, p1: 1f, p2: 1.5f);
        }
    }
}
