using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public float TimerAfterStartGame;
    public float TimerUntilRespawn;
    public GameObject Track;
    public GameObject Track2;
    public GameObject Track3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarCoroutineStart());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator CarCoroutineStart()
    {
        yield return new WaitForSeconds(TimerAfterStartGame);
        StartCoroutine(RespawnCoroutine());
    }
    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(Track, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track2, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track2, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track3, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track3, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track3, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Track2, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(TimerUntilRespawn);
        StartCoroutine(RespawnCoroutine());
    }
}
