using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose7 : MonoBehaviour
{
    public void BackToLevelMenu()
    {
        SceneManager.LoadScene("Level_Menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level_8");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level_7");
    }
}
