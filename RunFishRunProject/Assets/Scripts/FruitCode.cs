using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCode : Animation
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Fruit")
        {
            PlaySounds(audioClips[0], p1: 0.5f, p2: 1.5f);
        }
    }
}
