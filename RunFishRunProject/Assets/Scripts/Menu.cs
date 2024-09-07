using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
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
        SceneManager.LoadScene("SampleScene");
    }

}