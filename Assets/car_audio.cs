using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_audio : MonoBehaviour
{
    public AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            source.Play();
        }
        if(Input.GetKeyUp(KeyCode.W)) {
            source.Stop();
        }
    }
}
