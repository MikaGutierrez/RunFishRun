using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyBox : Animation
{ 
    public GameObject Pieces;
    public GameObject Self;
    private bool IsDestroyed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Puddle")
        {
            PlaySounds(audioClips[0]);
            StartCoroutine(GlassDestroy());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GlassDestroy()
    {
        if (IsDestroyed == false)
        {
            IsDestroyed = true;
            Instantiate(Pieces, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
        yield return new WaitForSeconds(0.45f);
        Destroy(Self);
    }
}
