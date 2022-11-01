using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose5 : MonoBehaviour
{
    public void BackToLevelMenu()
    {
        SceneManager.LoadScene("Level_Menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level_6");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level_5");
    }
}
