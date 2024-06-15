using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transmission_script : MonoBehaviour
{
    public List<Sprite> trans;
    private UnityEngine.UI.Image image;
    private CarController control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("player1").GetComponent<CarController>();
        image = GameObject.Find("trans_mode").GetComponent<UnityEngine.UI.Image>();
        image.sprite = trans[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(control.gearNum == -2) {
            image.sprite = trans[0];
        }
        if(control.gearNum == -1) {
            image.sprite = trans[1];            
        }
        if(control.gearNum == 0) {
            image.sprite = trans[2];            
        }
        if(control.gearNum == 1) {
            image.sprite = trans[3];            
        }
    }
}
