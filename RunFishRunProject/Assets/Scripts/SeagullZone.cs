using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullZone : MonoBehaviour
{
    public float lifeTime = 50;
    public float MinTime = 10;
    public float MaxTime = 50;
    public GameObject Player;
    public GameObject SeagullSpawn;
    public GameObject SeagullWarning;
    public bool IsPlayerOnZone = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsPlayerOnZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsPlayerOnZone = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = Random.Range(MinTime, MaxTime + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerOnZone == true)
        {
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                Instantiate(SeagullSpawn, new Vector3(Player.transform.position.x, Player.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(SeagullWarning, new Vector3(Player.transform.position.x, Player.transform.position.y + 3, 0f), Quaternion.Euler(0f, 0f, 0f));
                lifeTime = Random.Range(MinTime, MaxTime + 1);
            }
        }
    }


}
