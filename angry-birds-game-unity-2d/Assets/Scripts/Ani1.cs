using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani1 : MonoBehaviour
{
    public double time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
