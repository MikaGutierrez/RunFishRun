using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorScript : MonoBehaviour
{
    public Color ColorNow;
    public SpriteRenderer FishRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorNow = CharacterMovement.ColorNow;
        FishRenderer.color = ColorNow;
    }
}
