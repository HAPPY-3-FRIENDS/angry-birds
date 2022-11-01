using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject[] Enemies;

    int pigCount;

    void Start()
    {
        pigCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pigCount = 0;
        foreach(GameObject pig in Enemies)
        {
            if (pig != null)
            {
                pigCount++;
            }
        }

        if (pigCount == 0)
        {
            SceneManager.LoadScene("Level_Menu");
        }
    }
}
