using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!BGAudio.instance.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            BGAudio.instance.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
