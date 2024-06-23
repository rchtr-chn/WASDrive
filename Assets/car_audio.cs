using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    void Start() {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)  || Input.GetKeyDown(KeyCode.S)) {
            source.PlayOneShot(clip);
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
            source.Stop();
            source.PlayOneShot(clip2);
        }
        if(Input.GetKey(KeyCode.Space)) {
            source.Stop();
        }
    }
}
