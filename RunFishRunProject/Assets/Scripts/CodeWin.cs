using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CodeWin: Animation
{
    public GameObject Effect;
    public GameObject AppearEverything;
    private bool AfterAllIsDone = false;
    void Start()
    {
        Effect.SetActive(false);
        AppearEverything.SetActive(false);
    }

    void Update()
    {
        if (AfterAllIsDone == true && Input.anyKeyDown)
        {
            StartCoroutine(GoEffectExitSpetial());
        }
    }
    public void ExitToMenuSpetial()
    {
        StartCoroutine(GoEffectExitSpetial());
    }
    private IEnumerator GoEffectExitSpetial()
    {
        if (AfterAllIsDone == false)
        {
            Effect.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            AppearEverything.SetActive(true);
            //yield return new WaitForSeconds(3f);
            //SceneManager.LoadScene("MainMenu");
            AfterAllIsDone = true;
        }
        else
        {
            ChangeAnimationState(animationNames[1]);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}