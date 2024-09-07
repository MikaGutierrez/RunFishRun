using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float TimerAfterStartGame;
    public float TimerUntilRespawn;  
    public GameObject Car;
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
        Instantiate(Car, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(TimerUntilRespawn);
        StartCoroutine(RespawnCoroutine());
    }
}
