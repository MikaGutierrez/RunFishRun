using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private GameObject Player;
    public GameObject Self;
    public GameObject SoundCollectable;
    private bool IsDestroyed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterMovement.CollectblesCount += 1;
            StartCoroutine(Destroy());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator Destroy()
    {
        if (IsDestroyed == false)
        {
            IsDestroyed = true;
            Instantiate(SoundCollectable, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
        yield return new WaitForSeconds(0.005f);
        Destroy(Self);
    }
}
