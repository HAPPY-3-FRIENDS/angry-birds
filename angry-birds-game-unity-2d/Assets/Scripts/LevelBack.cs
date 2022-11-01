using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBack : MonoBehaviour
{
    public void BackToLevelMenu()
    {
        SceneManager.LoadScene("Level_Menu");
    }
}
