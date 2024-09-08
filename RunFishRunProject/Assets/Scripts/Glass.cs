using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject Self;
    public GameObject Pieces;
    private bool Destroyed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Destroyed == false)
        {
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
        Destroyed = true;
        Time.timeScale = 0.25f;
        Instantiate(Pieces, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.005f);
        Destroy(Self);
        yield return new WaitForSeconds(0.15f);
        Time.timeScale = 1f;
    }
}
