using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_condition_script : MonoBehaviour
{
    private CarController obj;
    private BoxCollider barrier;
    public int gearNum;
    public changeSceneScript logic;
    private camera_mouse_input camInput;


    void Start()
    {
        obj = GameObject.Find("player1").GetComponent<CarController>();
        barrier = GameObject.Find("out-barrier").GetComponent<BoxCollider>();
        barrier.enabled = false;
        logic = GameObject.Find("Logic").GetComponent<changeSceneScript>();
        camInput = GameObject.Find("Main Camera").GetComponent<camera_mouse_input>();
    }
    void Update()
    {
        if(barrier.enabled == true && gearNum == -2 && obj.backLeftWheel.motorTorque == 0f && obj.backRightWheel.motorTorque == 0f)
        {
            logic.stageClear();
            obj.enabled = false;
            camInput.enabled = false;
        }
        gearNum = obj.gearNum;
    }
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "player-tail")
        {
            barrier.enabled = true;
        }
    }
}
