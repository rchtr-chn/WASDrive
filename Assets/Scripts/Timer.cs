using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private changeSceneScript gameOver;
    private GameObject headParentText;
    private CarController controls;
    public float timer = 45f;

    private TextMeshProUGUI timerText;

    void Start()
    {
        gameOver = GetComponent<changeSceneScript>();
        controls = GameObject.Find("player1").GetComponent<CarController>();

        headParentText = GameObject.Find("Canvas");
        if(headParentText != null) {
            Transform parentText = headParentText.transform.Find("Timer Group");

            if(parentText != null) {
                Transform childText = parentText.transform.Find("Timer");

                if(childText != null) {
                    timerText = childText.GetComponent<TextMeshProUGUI>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && controls.enabled == true)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        Debug.Log(timer);
        if(timer < 0)
        {
            timerText.text = string.Format("00:00");
            gameOver.gameOver();
            controls.enabled = false;
        }

        int seconds = Mathf.FloorToInt(timer);
        if(timer < 10) {
            timerText.text = string.Format("00:0{0}", seconds);
        } else if(timer > 10){
            timerText.text = string.Format("00:{0}", seconds);
        }


    }
}
