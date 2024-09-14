using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Effect;
    void Start()
    {
        Effect.SetActive(false);
    }
    public void ExitClick()
    {
        Application.Quit();
    }

    public void StartClick()
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void AfterStorySceneClick()
    {
        StartCoroutine(GoEffect());
    }
    public void ExitToMenu()
    {
        StartCoroutine(GoEffectExit());
    }
    private IEnumerator GoEffect()
    {
        Effect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
    }
    private IEnumerator GoEffectExit()
    {
        Effect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
}