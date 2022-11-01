using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseAll6 : MonoBehaviour
{
    public Slingshot6 check;
    public GameObject Victory3;
    public GameObject Victory2;
    public GameObject Victory1;
    public GameObject Defeat;
    bool isChecked = false;

    void Update()
    {
        if (check.result == 1 && isChecked == false)
        {
            Victory1.SetActive(true);
            isChecked = true;
        }

        if (check.result == 2 && isChecked == false)
        {
            Victory2.SetActive(true);
            isChecked = true;
        }

        if (check.result == 3 && isChecked == false)
        {
            Victory3.SetActive(true);
            isChecked = true;
        }

        if (check.result == -1 && isChecked == false)
        {
            Defeat.SetActive(true);
            isChecked = true;
        }
    }
}
