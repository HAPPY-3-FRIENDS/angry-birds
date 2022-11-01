using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_Menu");
    }

    public void AboutUs()
    {
        SceneManager.LoadScene("About_Us");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
