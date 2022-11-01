using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBack : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
