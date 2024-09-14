using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEnding : MonoBehaviour
{
    public GameObject Effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(GoEffect());
        }
    }
        // Start is called before the first frame update
    void Start()
    {
        Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GoEffect()
    {
        Effect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GoodEnding");
    }
}
