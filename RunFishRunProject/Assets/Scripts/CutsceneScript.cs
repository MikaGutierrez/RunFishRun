using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public GameObject[] Frames;
    public GameObject Effect;
    public GameObject ButtonObject;
    public int WhatANumberOfFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        Effect.SetActive(true);
        Frames[0].SetActive(false);
        Frames[1].SetActive(false);
        Frames[2].SetActive(false);
        Frames[3].SetActive(false);
        Frames[4].SetActive(false);
        Frames[5].SetActive(false);
        Frames[6].SetActive(false);
        Frames[7].SetActive(false);
        StartCoroutine(StartIt());
        ButtonObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && WhatANumberOfFrame <7)
        {
            WhatANumberOfFrame += 1;
        }
        if (Input.anyKeyDown && WhatANumberOfFrame < 7)
        {
            Frames[WhatANumberOfFrame].SetActive(true);
        }

        if (WhatANumberOfFrame >= 7)
        {
            Frames[0].SetActive(false);
            Frames[1].SetActive(false);
            Frames[2].SetActive(false);
            Frames[3].SetActive(false);
            Frames[4].SetActive(false);
            Frames[5].SetActive(false);
            Frames[6].SetActive(false);
            Frames[7].SetActive(true);
            ButtonObject.SetActive(true);
        }
    }
    private IEnumerator StartIt()
    {
        yield return new WaitForSeconds(0.8f);
        Frames[0].SetActive(true);
    }
}
