using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class star_rating : MonoBehaviour
{
    public List<Sprite> choices;
    private UnityEngine.UI.Image image;
    private Timer timerr;

    void Start() {
        timerr = GameObject.Find("Logic").GetComponent<Timer>();
        image = GameObject.Find("Star Rating").GetComponent<UnityEngine.UI.Image>();
        image.sprite = choices[2];
    }

    void Update() {
        if(timerr.timer < 30 && timerr.timer > 15)
        {
            image.sprite = choices[1];
        }
        else if(timerr.timer < 15)
        {
            image.sprite = choices[0];
        }
    }
}
