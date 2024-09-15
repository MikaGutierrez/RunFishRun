using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Effect;
    private float speed = 5;
    public Rigidbody2D Track;
    void Start()
    {
        Time.timeScale = 1f;
        Effect.SetActive(false);
    }
    public void ExitClick()
    {
        Application.Quit();
    }

    public void StartClick()
    {
        StartCoroutine(GoStart());
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
    private IEnumerator GoStart()
    {
        Track.velocity = new Vector2(2, Track.velocity.y);
        yield return new WaitForSeconds(0.2f);
        Track.velocity = new Vector2(5, Track.velocity.y);
        yield return new WaitForSeconds(0.2f);
        Track.velocity = new Vector2(8, Track.velocity.y);
        yield return new WaitForSeconds(0.5f);
        Effect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("StoryScene");
    }
}